
// o_1_
module Cone_o_1_ (o_1_, i_6_, i_3_, i_8_, i_0_, i_5_, i_4_, i_7_, i_1_, i_2_ );
	input i_6_, i_3_, i_8_, i_0_, i_5_, i_4_, i_7_, i_1_, i_2_;
	output o_1_;
	wire n_12, n_14, n_8, n_7, n_3, n_5, n_2, n_16, n_4;
	OAI221X1 g2072(.IN1 (n_12), .IN2 (n_14), .IN3 (i_6_), .IN4 (n_2),
       .IN5 (n_16), .QN (o_1_));	INVX4 g2090(.IN (i_6_), .QN (n_12));	NOR2X4 g2078(.IN1 (n_8), .IN2 (n_5), .QN (n_14));	NAND2X2 g2080(.IN1 (n_7), .IN2 (i_5_), .QN (n_8));	NOR2X4 g2082(.IN1 (n_3), .IN2 (i_0_), .QN (n_7));	ISOLANDX1 g2084(.ISO (i_3_), .D (i_8_), .Q (n_3));	ISOLANDX2 g2085(.ISO (i_4_), .D (i_7_), .Q (n_5));	NAND2X1 g2086(.IN1 (i_1_), .IN2 (i_2_), .QN (n_2));	NAND3X2 g2083(.IN1 (n_4), .IN2 (n_12), .IN3 (i_0_), .QN (n_16));	INVX2 g2089(.IN (i_5_), .QN (n_4));
endmodule

