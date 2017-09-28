
// n_15
module Cone_n_15 (n_15, i_3_, i_8_, i_0_, i_5_, i_4_, i_7_, i_6_ );
	input i_3_, i_8_, i_0_, i_5_, i_4_, i_7_, i_6_;
	output n_15;
	wire n_14, n_8, n_7, n_3, n_5;
	NAND2X2 g2076(.IN1 (n_14), .IN2 (i_6_), .QN (n_15));	NOR2X4 g2078(.IN1 (n_8), .IN2 (n_5), .QN (n_14));	NAND2X2 g2080(.IN1 (n_7), .IN2 (i_5_), .QN (n_8));	NOR2X4 g2082(.IN1 (n_3), .IN2 (i_0_), .QN (n_7));	ISOLANDX1 g2084(.ISO (i_3_), .D (i_8_), .Q (n_3));	ISOLANDX2 g2085(.ISO (i_4_), .D (i_7_), .Q (n_5));
endmodule

