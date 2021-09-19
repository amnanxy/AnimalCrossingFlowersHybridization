using System.Collections;
using System.Collections.Generic;

namespace AnimalCrossingFlowersHybridization
{
    internal class Meiosis : IEnumerable<Gamete>
    {
        private readonly Locus _locus;
        private readonly Meiosis _meiosis;

        public Meiosis(Locus locus, Meiosis meiosis)
        {
            _locus = locus;
            _meiosis = meiosis;
        }

        public IEnumerator<Gamete> GetEnumerator()
        {
            if (_meiosis == null)
            {
                foreach (var trait in _locus.Traits)
                {
                    yield return new Gamete(new List<char> { trait });
                }
            }
            else
            {
                foreach (var trait in _locus.Traits)
                {
                    foreach (var gamete in _meiosis)
                    {
                        gamete.Genes.Add(trait);
                        yield return gamete;
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}