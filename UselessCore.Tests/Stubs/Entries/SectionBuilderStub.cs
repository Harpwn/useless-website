using System.Collections.Generic;
using UselessCore.Services.Entries;

namespace UselessCore.Tests.Stubs.Entries
{
    public class SectionBuilderStub : ISectionBuilder
    {
        public void BuildCounteredBySection()
        {
        }

        public void BuildMainTagSection()
        {
        }

        public void BuildSimilarInGameSection()
        {
        }

        public void BuildSimilarInGenreSection()
        {
        }

        public void BuildStrongAgainstSection()
        {
        }

        public void BuildSynergizesWithSection()
        {
        }

        public void BuildTierSection()
        {
        }

        public void BuildTipsSection()
        {
        }

        public List<ISection> GetResult()
        {
            return new List<ISection>();
        }
    }
}
