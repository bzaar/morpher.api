using System;
using System.Collections.Generic;

namespace Morpher
{
    public interface IGenderParadigm
    {
        string Masculine {get;}
        string Feminine  {get;}
        string Neuter    {get;}
        string Plural    {get;}
    }

    public interface IGender
    {
        string Get (IGenderParadigm paradigm);
    }

    public class Gender : IGender
    {
        private readonly Func <IGenderParadigm, string> func;

        private Gender (Func<IGenderParadigm, string> func)
        {
            this.func = func;
        }

        string IGender.Get(IGenderParadigm paradigm)
        {
            return func (paradigm);
        }

        public static IGender Masculine = new Gender (p => p.Masculine);
        public static IGender Feminine  = new Gender (p => p.Feminine);
        public static IGender Neuter    = new Gender (p => p.Neuter);
        public static IGender Plural    = new Gender (p => p.Plural);
    }

    public interface IFullParadigm <TParadigm>
    {
        TParadigm Singular {get;}
        TParadigm Plural   {get;}
    }

    public interface ICase <TParadigm>
    {
        string Get (TParadigm paradigm);
    }

    public interface ILanguage <TParadigm> 
    {
        IEnumerable <ICase <TParadigm>> Cases {get;}

        ICase <TParadigm> Nominative {get;}
    }

    public interface IDeclension <TParadigm> : ILanguage <TParadigm> 
    {
        IFullParadigm <TParadigm> Analyse(string s);
    }

    public interface INumberSpelling <TParadigm> : ILanguage <TParadigm> 
    {
        string Spell (decimal n, ref string unit, ICase <TParadigm> @case);
    }

    public static class ParadigmExtensions
    {
        public static string Get <TParidigm> (this TParidigm paridigm, ICase <TParidigm> @case)
        {
            return @case.Get (paridigm);
        }
    }

    public interface ISlavicParadigm 
    {
        string Nominative    {get;}
        string Genitive      {get;}
        string Dative        {get;}
        string Accusative    {get;}
        string Instrumental  {get;}
        string Prepositional {get;}
    }

    public interface ISlavicNumberSpelling
    {
        string Spell (decimal n, ref string unit, ICase <ISlavicParadigm> @case);
    }
}

