using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public static class Mapper
    {
        
        public static DomainEntities.Genre Map(Entities.Genre g) => new DomainEntities.Genre
        {
            
        };





        //how it looks in my code
        //public static Domain.DomainEntities.Inventory Map(Entities.Inventory i) => new Domain.DomainEntities.Inventory
        //{
        //    Id = i.InventoryId,
        //    Quantity = i.Quantity,
        //    LocationID = i.LocationId,
        //};
        //public static Entities.Inventory Map(Domain.DomainEntities.Inventory i) => new Entities.Inventory
        //{
        //    Quantity = i.Quantity,
        //    LocationId = i.LocationID
        //};

        //public static IEnumerable<Domain.DomainEntities.Inventory> Map(IEnumerable<Entities.Inventory> i) => i.Select(Map);
        //public static IEnumerable<Entities.Inventory> Map(IEnumerable<Domain.DomainEntities.Inventory> i) => i.Select(Map);
    }
}
