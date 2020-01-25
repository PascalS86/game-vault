using System;

namespace Csandra.game_vault.wasm.App.Data
{
    public class GameVaultData
    {
        public string ID {get;set;}
        public string Spieltitel { get; set; }
        public string Spielerzahl { get; set; }
        public int Komplexitaet { get; set; }
        public string Mechanik { get; set; }
        public int Spielhäufigkeit { get; set; }
        public DateTime? ZuletztGespielt { get; set; }
        public string Dauer { get; set; }

        public string PictureUri{get;set;}
    }
}