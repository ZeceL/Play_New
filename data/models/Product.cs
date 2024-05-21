namespace Play_New.data.models
{
    public class Product
    {

        public int id_product { get; set; }

        public int id_director { get; set; }

        public string name_product { get; set; }

        public int id_genre { get; set; }

        public string duration_product { get; set;}

        public int? album { get; set;}

        public int country { get; set;}

        public string release_date { get; set;}

        public int language { get; set;}

        public int type_product { get; set;}

        public string? data_product { get; set;}

        public string picture { get; set; }
    }
}
