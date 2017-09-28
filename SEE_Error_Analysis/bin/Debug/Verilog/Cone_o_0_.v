
// o_0_
module Cone_o_0_ (o_0_, i_2_, i_3_, i_8_, i_0_, i_5_, i_4_, i_7_, i_6_, i_1_ );
	input i_2_, i_3_, i_8_, i_0_, i_5_, i_4_, i_7_, i_6_, i_1_;
	output o_0_;
	wire n_18, n_15, n_14, n_8, n_7, n_3, n_5, n_0, n_16, n_4, n_12;
	OAI221X1 g2071(.IN1 (i_2_), .IN2 (n_18), .IN3 (i_1_), .IN4 (n_0),
       .IN5 (n_16), .QN (o_0_));	NAND2X2 g2074(.IN1 (n_15), .IN2 (i_1_), .QN (n_18));	NAND2X2 g2076(.IN1 (n_14), .IN2 (i_6_), .QN (n_15));	NOR2X4 g2078(.IN1 (n_8), .IN2 (n_5), .QN (n_14));	NAND2X2 g2080(.IN1 (n_7), .IN2 (i_5_), .QN (n_8));	NOR2X4 g2082(.IN1 (n_3), .IN2 (i_0_), .QN (n_7));	ISOLANDX1 g2084(.ISO (i_3_), .D (i_8_), .Q (n_3));	ISOLANDX2 g2085(.ISO (i_4_), .D (i_7_), .Q (n_5));	INVX1 g2088(.IN (i_2_), .QN (n_0));	NAND3X2 g2083(.IN1 (n_4), .IN2 (n_12), .IN3 (i_0_), .QN (n_16));	INVX2 g2089(.IN (i_5_), .QN (n_4));	INVX4 g2090(.IN (i_6_), .QN (n_12));
endmodule

