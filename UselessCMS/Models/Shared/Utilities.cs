using UselessCore.Enums;

namespace UselessCMS.Models.Shared
{
    public static class Utilities
    {
        public static EnumViewModel Translate(this EnumDto dto)
        {
            return new EnumViewModel
            {
                ID = dto.ID,
                Name = dto.Name
            };
        }

    }
}
