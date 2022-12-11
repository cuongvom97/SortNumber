namespace back_end.services
{
    public class Number : INumber
    {
        public Number() { }
        public string Sort(string number)
        {
            var arrNumber = Array.ConvertAll(number.Split(','), x =>
            {
                if (int.TryParse(x, out int n))
                {
                    return int.Parse(x);
                }
                throw new Exception();
            });
            Array.Sort(arrNumber);
            Array.Reverse(arrNumber);
            var middle = arrNumber.Take(10);
            var left = arrNumber.Skip(10).Take(10);
            var right = arrNumber.Skip(20).Take(10);
            var others = arrNumber.Skip(30);
            float numberItemWillTake = others.Count() / 2;
            var rounding = (int)Math.Round(numberItemWillTake, MidpointRounding.ToEven);
            switch (arrNumber.Count())
            {
                case 30:
                    return String.Format("<{0}><{1}><{2}>",
                        JoinComma(left),
                        JoinComma(middle),
                        JoinComma(right));
                case 31:
                    return String.Format("<{0}><{1}><{2}><{3}>",
                        JoinComma(left),
                        JoinComma(others.Take(1)),
                        JoinComma(middle),
                        JoinComma(right));
                default:
                    return String.Format("<{0}><{1}><{2}><{3}><{4}>",
                        JoinComma(left),
                        JoinComma(others.Take(rounding)),
                        JoinComma(middle),
                        JoinComma(others.Skip(rounding)),
                        JoinComma(right));
            }
        }

        private string JoinComma(IEnumerable<int> arr)
        {
            return String.Join(',', arr);
        }
    }
}