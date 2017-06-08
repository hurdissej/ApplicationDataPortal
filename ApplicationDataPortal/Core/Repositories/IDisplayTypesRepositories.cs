using System.Collections.Generic;
using ApplicationDataPortal.Core.Dtos;
using ApplicationDataPortal.Core.Models;

namespace ApplicationDataPortal.Core.Repositories
{
    public interface IDisplayTypesRepositories
    {
        IEnumerable<DisplayTypes> GetDisplayTypes();
        DisplayTypes GetDisplayType(int Id);
        void UpdateDisplayType(DisplayTypeDto displayTypeDto, DisplayTypes displayTypeInDb);
        void DeleteDisplayType(int Id);
        void CreateDisplayType(DisplayTypeDto displayTypeDto);
    }
}