
// n_10
module Cone_n_10 (n_10, i_3_, i_8_, i_0_, i_4_, i_7_, i_6_ );
	input i_3_, i_8_, i_0_, i_4_, i_7_, i_6_;
	output n_10;
	wire n_7, n_3, n_6, n_5;
	AND3X2 g2079(.IN1 (n_7), .IN2 (n_6), .IN3 (i_6_), .Q (n_10));	NOR2X4 g2082(.IN1 (n_3), .IN2 (i_0_), .QN (n_7));	ISOLANDX1 g2084(.ISO (i_3_), .D (i_8_), .Q (n_3));	NAND2X2 g2081(.IN1 (n_5), .IN2 (i_8_), .QN (n_6));	ISOLANDX2 g2085(.ISO (i_4_), .D (i_7_), .Q (n_5));
endmodule

