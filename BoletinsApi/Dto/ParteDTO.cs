﻿namespace FirstAPI.Models
{
    public class ParteDTO
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public List<TelefoneDTO> Telefones { get; set; }
    }
}
