﻿using System;

namespace Ebd.Domain.Core.Entities
{
    public class Chamada
    {
        public Chamada(int alunoId, int licaoId, bool estavaPresente, DateTime data)
        {
            EstavaPresente = estavaPresente;
            Data = data;
            AlunoId = alunoId;
            LicaoId = licaoId;
        }

        public int ChamadaId { get; private set; }
        public bool EstavaPresente { get; private set; }
        public DateTime Data { get; private set; }

        public int AlunoId { get; private set; }
        public Aluno Aluno { get; private set; }

        public int LicaoId { get; private set; }
        public Licao Licao { get; private set; }
    }
}
