using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Models
{
    public class InventoryTransaction : BaseModel
    {
        public required int Quatity { get; set; }
        public required DateTime Date { get; set; }

        public int ProductId { get; set; }
        public Product? Product { get; set; }

        public int StoreId { get; set; }
        public Store? Store { get; set; }

    }

    public class InventoryTransactionCreateDTO
    {
        public required int Quatity { get; set; }
        public int ProductId { get; set; }
        public int StoreId { get; set; }
    }

    public class InventoryTransactionUpdateDTO : InventoryTransactionCreateDTO { }

}
