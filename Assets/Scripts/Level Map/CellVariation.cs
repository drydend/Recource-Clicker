namespace LevelMap
{
    public enum CellVariation
    {
        FullSides,

        Plain,
        Plain_TR_BR_BL_TL_Corners,
        
        Plain_TR_BR_BL_Corners,
        Plain_TR_BR_TL_Corners,
        Plain_TR_BL_TL_Corners,
        Plain_BR_BL_TL_Corners,
        
        Plain_TR_BL_Corners,
        Plain_TL_BR_Corners,
        Plain_TR_TL_Corners,
        Plain_TR_BR_Corners,
        Plain_BR_BL_Corners,
        Plain_BL_TL_Corners,

        Plain_TR_Corner,
        Plain_BR_Corner,
        Plain_BL_Corner,
        Plain_TL_Corner,

        LTB_Sides,
        RTB_Sides,
        TRL_Sides,
        BRL_Sides,

        TB_Sides,
        RL_Sides,

        LB_Sides,
        LB_Sides_TR_Corner,

        TL_Sides,
        TL_Sides_BR_Corner,
        
        RT_Sides,
        RT_Sides_BL_Corner,
        
        RB_Sides,
        RB_Sides_TL_Corner,


        L_Side,
        L_Side_BR_TR_Corners,
        L_Side_BR_Corner,
        L_Side_TR_Corner,

        R_Side,
        R_Side_BL_TL_Corners,
        R_Side_BL_Corner,
        R_Side_TL_Corner,

        T_Side,
        T_Side_BL_BR_Corners,
        T_Side_BL_Corner,
        T_Side_BR_Corner,

        B_Side,
        B_Side_TL_TR_Corners,
        B_Side_TL_Corner,
        B_Side_TR_Corner
    }
}