
// n_8
module Cone_n_8 (n_8, i_3_, i_8_, i_0_, i_5_ );
	input i_3_, i_8_, i_0_, i_5_;
	output n_8;
	wire n_7, n_3;
	NAND2X2 g2080(.IN1 (n_7), .IN2 (i_5_), .QN (n_8));	NOR2X4 g2082(.IN1 (n_3), .IN2 (i_0_), .QN (n_7));	ISOLANDX1 g2084(.ISO (i_3_), .D (i_8_), .Q (n_3));
endmodule

