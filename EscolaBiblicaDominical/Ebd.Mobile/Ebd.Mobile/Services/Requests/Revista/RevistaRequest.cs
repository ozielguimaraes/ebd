﻿namespace Ebd.Mobile.Services.Requests.Revista
{
    public class AdicionarRevistaRequest
    {
        public int RevistaId { get; set; }
        public string Sumario { get; set; }
        public int Ano { get; set; }
        public int Trimestre { get; set; }
    }
}
