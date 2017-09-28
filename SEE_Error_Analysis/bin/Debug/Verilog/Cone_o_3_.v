
// o_3_
module Cone_o_3_ (o_3_, i_3_, i_8_, i_0_, i_4_, i_7_, i_6_, i_5_ );
	input i_3_, i_8_, i_0_, i_4_, i_7_, i_6_, i_5_;
	output o_3_;
	wire n_10, n_7, n_3, n_6, n_5, n_4, n_1, n_12;
	AO222X1 g2073(.IN1 (n_10), .IN2 (n_4), .IN3 (i_6_), .IN4 (i_0_), .IN5
       (n_1), .IN6 (n_12), .Q (o_3_));	AND3X2 g2079(.IN1 (n_7), .IN2 (n_6), .IN3 (i_6_), .Q (n_10));	NOR2X4 g2082(.IN1 (n_3), .IN2 (i_0_), .QN (n_7));	ISOLANDX1 g2084(.ISO (i_3_), .D (i_8_), .Q (n_3));	NAND2X2 g2081(.IN1 (n_5), .IN2 (i_8_), .QN (n_6));	ISOLANDX2 g2085(.ISO (i_4_), .D (i_7_), .Q (n_5));	INVX2 g2089(.IN (i_5_), .QN (n_4));	NAND2X1 g2087(.IN1 (i_0_), .IN2 (i_5_), .QN (n_1));	INVX4 g2090(.IN (i_6_), .QN (n_12));
endmodule

