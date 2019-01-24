using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 namespace Constants {
    namespace Truco
    {
        namespace Card
        {
            public enum Type
            {
                NADA = 0,
                COPA = 1,
                BASTO = 2,
                ORO = 3,
                ESPADA = 4,
            }

            public enum Number
            {
                NADA = 0,
                UNO = 1,
                DOS = 2,
                TRES = 3,
                CUATRO = 4,
                CINCO = 5,
                SEIS = 6,
                SIETE = 7,
                DIEZ = 10,
                ONCE = 11,
                DOCE = 12,
            }

			public enum Rank
			{
				NADA = 0,
				LOS_4 = 1,
				LOS_5 = 2,
				LOS_6 = 3,
				LOS_7_COPA_Y_BASTO = 4,
				LOS_10 = 5,
				LOS_11 = 6,
				LOS_12 = 7,
				LOS_1_ORO_Y_COPA = 8,
				LOS_2 = 9,
				LOS_3 = 10,
				EL_7_ORO = 11,
				EL_7_ESPADA = 12,
				HEMBRA = 13,
				MACHO  = 14,
			}
        }

        public enum TrucoAction
        {
            NADA = 0,
            TRUCO = 1,
            RETRUCO = 2,
            VALECUATRO = 3,
            ENVIDO = 4,
            REAL_ENVIDO = 5,
            FALTA_ENVIDO = 6,
            FLOR = 7,

        }

        public enum TrucoResponse
        {
            NADA = 0,
            QUIERO = 1,
            NO_QUIERO = 2,
        }
        
        public enum TrucoState
        {
            NADA = 0,
			TRUCO_CANTADO = 1,
            TRUCO_RECHAZADO = 2,
            TRUCO_QUERIDO = 3,
			RETRUCO_CANTADO = 4,
            RETRUCO_RECHAZADO = 5,
            RETRUCO_QUERIDO = 6,
			VALECUATRO_CANTADO = 7,
            VALECUATRO_RECHAZADO = 8,
            VALECUATRO_QUERIDO = 9,
        }

        public enum EnvidoState
        {
            NADA = 0,
			ENVIDO_CANTADO = 1,
            ENVIDO_RECHAZADO = 2,
            ENVIDO_QUERIDO = 3,
			REAL_ENVIDO_CANTADO = 4,
			REAL_ENVIDO_QUERIDO = 5,
			REAL_ENVIDO_RECHAZADO = 6,
			ENVIDO_ENVIDO_CANTADO = 7,
			ENVIDO_ENVIDO_QUERIDO = 8,
			ENVIDO_ENVIDO_RECHAZADO = 9,
            ENVIDO_REAL_ENVIDO_CANTADO = 10,
			ENVIDO_REAL_ENVIDO_RECHAZADO = 11,
			ENVIDO_REAL_ENVIDO_QUERIDO = 12,
			ENVIDO_FALTA_ENVIDO_CANTADO = 13,
			ENVIDO_FALTA_ENVIDO_RECHAZADO = 14,
			ENVIDO_FALTA_ENVIDO_QUERIDO = 15,
			ENVIDO_ENVIDO_REAL_ENVIDO_CANTADO = 16,
			ENVIDO_ENVIDO_REAL_ENVIDO_RECHAZADO = 17,
			ENVIDO_ENVIDO_REAL_ENVIDO_QUERIDO = 18,
			ENVIDO_ENVIDO_FALTA_ENVIDO_CANTADO = 19,
			ENVIDO_ENVIDO_FALTA_ENVIDO_RECHAZADO = 20,
			ENVIDO_ENVIDO_FALTA_ENVIDO_QUERIDO = 21,
			ENVIDO_REAL_ENVIDO_FALTA_ENVIDO_CANTADO = 22,
			ENVIDO_REAL_ENVIDO_FALTA_ENVIDO_RECHAZADO = 23,
			ENVIDO_REAL_ENVIDO_FALTA_ENVIDO_QUERIDO = 24,
			ENVIDO_ENVIDO_REAL_ENVIDO_FALTA_ENVIDO_CANTADO = 25,
			ENVIDO_ENVIDO_REAL_ENVIDO_FALTA_ENVIDO_RECHAZADO = 26,
			ENVIDO_ENVIDO_REAL_ENVIDO_FALTA_ENVIDO_QUERIDO = 27,
			REAL_ENVIDO_FALTA_ENVIDO_CANTADO = 28,
			REAL_ENVIDO_FALTA_ENVIDO_RECHAZADO = 29,
			REAL_ENVIDO_FALTA_ENVIDO_QUERIDO = 30,
			FALTA_ENVIDO_CANTADO = 31,
			FALTA_ENVIDO_RECHAZADO = 32,
            FALTA_ENVIDO_QUERIDO = 33,
        }

        public enum FlorState
        {
            NADA = 0,
            FLOR_CANTADO = 1,
            FLOR_QUERIDO = 2,
            FLOR_FLOR_CANTADO = 3,
            FLOR_FLOR_RECHAZADO = 4,
            FLOR_FLOR_QUERIDO = 5,
            FLOR_CONTRAFLOR_CANTADO = 6,
			FLOR_CONTRAFLOR_RECHAZADO = 7,
			FLOR_CONTRAFLOR_QUERIDO = 8,
            FLOR_FLOR_CONTRAFLOR_CANTADO = 9,
			FLOR_FLOR_CONTRAFLOR_RECHAZADO = 10,
			FLOR_FLOR_CONTRAFLOR_QUERIDO = 11,     
        }

        public enum Player
        {
            NO_ONE = 0,
            PLAYER_1 = 1,
            PLAYER_2 = 2,
        }

        public enum ActionCaller
        {
            NO_ONE = 0,
            PLAYER_1 = 1,
            PLAYER_2 = 2,
        }

		public enum EnvidoWinner
		{
			NO_ONE = 0,
			PLAYER_1 = 1,
			PLAYER_2 = 2,
		}

		public enum HandWinner
		{
			NO_ONE = 0,
			PLAYER_1 = 1,
			PLAYER_2 = 2,
		}

		public enum FlorWinner
		{
			NO_ONE = 0,
			PLAYER_1 = 1,
			PLAYER_2 = 2,
		}
    }
}