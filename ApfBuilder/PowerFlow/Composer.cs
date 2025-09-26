using ApfBuilder.Criteria.Core.Interfaces;
using MoreLinq;
using System.Linq;

namespace ApfBuilder.PowerFlow
{
    public abstract class Composer : IComposer
    {
        public abstract void Compose();

        protected string GetValuePrefix(string value, bool canBeUse) =>
            canBeUse ? $"МИН\n({value})" : value.TrimEnd();

        protected string GetDescriptionPrefix(string value, bool canBeUse) =>
            canBeUse ? $"\n{value}" : value.TrimEnd();

        protected string TerminateLine(string text)
        {
            return $"{text.TrimEnd(' ')};\n";
        }

        protected (string Value, string Description) EmergencyResponseCompose(
            string value, string description, 
            IEmergencyResponseCriterion emergencyCriterion)
        {
            string responce = string.Empty;
            emergencyCriterion.EmergencyResponse.ForEach(
                (x) => responce += " + " + x.Description
                );

            value +=
                (emergencyCriterion.EmergencyResponse.Any() ?
                responce : "");

            description +=
                (emergencyCriterion.EmergencyResponse.Any() ?
                "+ УВ" : "");

            return (value, description);
        }
    }
}
