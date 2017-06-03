using System.Collections.Generic;
using ApplicationDataPortal.Dtos;
using ApplicationDataPortal.Models;

namespace ApplicationDataPortal.Repositories
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