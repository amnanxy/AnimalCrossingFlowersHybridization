using System.Collections;
using System.Collections.Generic;

namespace AnimalCrossingFlowersHybridization
{
    internal class Meiosis : IEnumerable<List<char>>
    {
        private readonly Locus _locus;
        private readonly Meiosis _meiosis;

        public Meiosis(Locus locus, Meiosis meiosis)
        {
            _locus = locus;
            _meiosis = meiosis;
        }

        public IEnumerator<List<char>> GetEnumerator()
        {
            foreach (var trait in _locus.Traits)
            {
                if (_meiosis == null)
                {
                    yield return new List<char> { trait };
                }
                else
                {
                    foreach (var m in _meiosis)
                    {
                        m.Add(trait);
                        yield return m;
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