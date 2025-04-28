using System;

namespace MoneyApp
{
    /// <summary>
    /// класс содержащий методы и поля для работы с деньгами
    /// </summary>
    public class Money
    {

        private uint rubles;
        private byte kopeks;

        public uint Rubles { get { return rubles; } }
        public byte Kopeks { get { return kopeks; } }

        /// <summary>
        /// стандартный конструктор
        /// </summary>
        public Money()
        {
            rubles = 0;
            kopeks = 0;
        }

        /// <summary>
        /// конструктор с параметрами
        /// </summary>
        /// <param name="x">рубли</param>
        /// <param name="y">копейки</param>
        /// <exception cref="ArgumentException">если вводится более 100 копеек</exception>
        public Money(uint x, byte y)
        {
            if (y >= 100)
                throw new ArgumentException("Количество копеек не может быть больше 100");

            rubles = x;
            kopeks = y;
        }

        /// <summary>
        /// перегрузка оператора -
        /// </summary>
        /// <param name="a">объект из которого вычетают</param>
        /// <param name="b">объект котороый вычетают</param>
        /// <returns>новый объект</returns>
        public static Money operator -(Money a, Money b)
        {
            uint rublesn;
            byte kopeksn;

            if (a.kopeks >= b.kopeks)
            {
                kopeksn = (byte)(a.kopeks - b.kopeks);
                if (a.rubles >= b.rubles)
                {
                    rublesn = a.rubles - b.rubles;
                }
                else
                {
                    rublesn = 0;
                    kopeksn = 0;
                }
            }
            else
            {
                kopeksn = (byte)(100 - (b.kopeks - a.kopeks));

                if (a.rubles > b.rubles)
                {
                    rublesn = a.rubles - b.rubles - 1;
                }
                else
                {
                    rublesn = 0;
                    kopeksn = 0;
                }
            }

            return new Money(rublesn, kopeksn);
        }

        /// <summary>
        /// перегрузка оператора ++, увеличение на 1 копейку
        /// </summary>
        /// <param name="x">обьект который необходимо увеличить</param>
        /// <returns>объект</returns>
        public static Money operator ++(Money x)
        {
            x.kopeks++;
            if (x.kopeks >= 100)
            {
                x.rubles += (uint)(x.kopeks / 100);
                x.kopeks = (byte)(x.kopeks % 100);
            }
            return x;
        }

        /// <summary>
        /// перегрузка оператора --, уменьшение на 1 копейку
        /// </summary>
        /// <param name="x">обьект который необходимо уменьшить</param>
        /// <returns>объект</returns>
        public static Money operator --(Money x)
        {
            if (x.kopeks > 0)
            {
                x.kopeks--;
            }
            else if (x.rubles > 0)
            {
                x.rubles--;
                x.kopeks = 99;
            }
            return x;
        }

        public static implicit operator uint(Money money)
        {
            return money.rubles;
        }

        public static explicit operator double(Money money)
        {
            return money.kopeks / 100.0;
        }

        /// <summary>
        /// перегрузка оператора -, вычетание рублей из объекта
        /// </summary>
        /// <param name="money">объект Money</param>
        /// <param name="rublesToSubtract">целое число рублей</param>
        /// <returns>новый объект</returns>
        public static Money operator -(Money money, uint rublesToSubtract)
        {
            if (rublesToSubtract > money.rubles)
                return new Money(0, 0);

            return new Money(money.rubles - rublesToSubtract, money.kopeks);
        }

        /// <summary>
        /// перегрузка оператора -, вычетание объекта из рублей 
        /// </summary>
        /// <param name="money">объект Money</param>
        /// <param name="rublesToSubtract">целое число рублей</param>
        /// <returns>новый объект</returns>
        public static Money operator -(uint rublesToSubtract, Money money)
        {
            ulong totalMoneyKopeks = (ulong)money.rubles * 100 + money.kopeks;
            ulong totalSubtractKopeks = (ulong)rublesToSubtract * 100;

            if (totalSubtractKopeks < totalMoneyKopeks)
                return new Money(0, 0);

            ulong resultKopeks = totalSubtractKopeks - totalMoneyKopeks;
            uint resultRubles = (uint)(resultKopeks / 100);
            byte resultKopeks1 = (byte)(resultKopeks % 100);

            return new Money(resultRubles, resultKopeks1);
        }

        /// <summary>
        /// вывод на экран
        /// </summary>
        /// <returns>строка с рублями и копейками</returns>
        public override string ToString()
        {
            return $"{rubles} рублей, {kopeks} копеек";
        }
    }
}