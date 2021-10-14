using System;

namespace CollegeImport
{
    public class Fio
    {
        public string LastName;
        public string FirstName;
        public string MiddleName;
    }

    public interface IFioCreator
    {
        string FioToShortString(Fio fio);
        string FioToLongString(Fio fio);
        Fio ParseShortFio(string shortFio);
        Fio ParseLongFio(string longFio);
    }

    [Obsolete]
    public class NormalFormFioCreator : IFioCreator 
    {
        public string FioToShortString(Fio fio)
        {
            return String.Format("{0} {1}. {2}.", fio.LastName, fio.FirstName[0], fio.MiddleName[0]);
        }

        public Fio ParseShortFio(string shortFio)
        {
            string[] tokens = StringHelper.SplitBy(shortFio, ' ');
            return new Fio{ LastName = tokens[0], FirstName = tokens[1][0].ToString(), MiddleName = tokens[2][0].ToString() };
        }

        public string FioToLongString(Fio fio)
        {
            return String.Format("{0} {1} {2}", fio.LastName, fio.FirstName, fio.MiddleName);
        }

        public Fio ParseLongFio(string longFio)
        {
            string[] tokens = StringHelper.SplitBy(longFio, ' ');
            return new Fio{ LastName = tokens[0], FirstName = tokens[1], MiddleName = tokens[2] };
        }
    }

    public class SmartFioCreator : IFioCreator
    {
        public string FioToShortString(Fio fio)
        {
            if (FioWithMistake(fio)) return fio.LastName;
            return String.Format("{0} {1}. {2}.", fio.LastName, fio.FirstName[0], fio.MiddleName[0]);
        }

        public string FioToLongString(Fio fio)
        {
            if (FioWithMistake(fio)) return fio.LastName;
            return String.Format("{0} {1} {2}", fio.LastName, fio.FirstName, fio.MiddleName);
        }

        private bool FioWithMistake(Fio fio)
        {
            return String.IsNullOrWhiteSpace(fio.LastName) ||
                   String.IsNullOrWhiteSpace(fio.FirstName) ||
                   String.IsNullOrWhiteSpace(fio.MiddleName) ||
                   fio.FirstName.Length == 0 ||
                   fio.MiddleName.Length == 0;
        }

        public Fio ParseShortFio(string shortFio)
        {
            return ParserFio(shortFio);
        }

        public Fio ParseLongFio(string longFio)
        {
            return ParserFio(longFio);
        }

        private Fio ParserFio(string fio)
        {
            string[] tokens = StringHelper.SplitBy(fio, ' ');
            try
            {
                if (tokens.Length == 3)
                    return new Fio() { LastName = tokens[0], FirstName = tokens[1], MiddleName = tokens[2] };
            }
            catch (Exception)
            { }
            return new Fio() { LastName = fio, FirstName = null, MiddleName = null };
        }
    }
}