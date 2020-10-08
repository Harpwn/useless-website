using System;
using System.Collections.Generic;
using System.Text;

namespace UselessCore.Services.Entries
{
    public interface ISectionBuilder
    {
        List<ISection> GetResult();

        void BuildMainTagSection();
        void BuildTierSection();
        void BuildTipsSection();
        void BuildSimilarInGameSection();
        void BuildSimilarInGenreSection();
        void BuildCounteredBySection();
        void BuildStrongAgainstSection();
        void BuildSynergizesWithSection();
    }
}
