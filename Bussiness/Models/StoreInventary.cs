namespace Bussiness.Models
{
    public class StoreInventary : BaseModel
    {
        public int ProductId { get; set; }
        public Product? Product { get; set; }

        public int StoreId { get; set; }
        public Store? Store { get; set; }

        public required int Stock { get; set; }

        public IEnumerable<InventoryTransaction> Transacctions { get; set; } = new List<InventoryTransaction>();
    }

    //TODO: Tenemos un problema de diseño, lo que sucede es lo siguiente
    /*
     * Primero: Stock no puede ir en en la tabla products por que solamente estaría contabilizando 
     * el stock total y no el de cada tienda.
     * 
     * Segundo: Esta tabla no tiene sentido su campo Date porqué no se tendría un registro de cuales 
     * veces y fechas se han hecho entradas y salidas de articulos.
     *  
     *  Posible soución: Hacer una tabla extra para manipular las entradas y qué esta tabla sea 
     *  únicamente del stock total de un producto en una tienda.
     *  
     *  La tabla esa tendrá la fecha y el StoreId como ProductIt y deberá estar relacionada a una 
     *  tabla intermedia
     */
    public class StoreInventaryCreateDTO
    {
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public int StoreId { get; set; }
        public Store? Store { get; set; }
        public required int Stock { get; set; }
    }

    public class StoreInventaryUpdateDTO : BaseModel
    {
        public required int ProductId { get; set; }
        public Product? Product { get; set; }

        public required int StoreId { get; set; }
        public Store? Store { get; set; }

        public required int Stock { get; set; }


    }
}
