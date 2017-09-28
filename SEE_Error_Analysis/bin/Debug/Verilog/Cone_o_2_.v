
// o_2_
module Cone_o_2_ (o_2_, i_3_, i_8_, i_0_, i_5_, i_6_ );
	input i_3_, i_8_, i_0_, i_5_, i_6_;
	output o_2_;
	wire n_8, n_7, n_3, n_12;
	OR2X1 g2077(.IN1 (n_8), .IN2 (n_12), .Q (o_2_));	NAND2X2 g2080(.IN1 (n_7), .IN2 (i_5_), .QN (n_8));	NOR2X4 g2082(.IN1 (n_3), .IN2 (i_0_), .QN (n_7));	ISOLANDX1 g2084(.ISO (i_3_), .D (i_8_), .Q (n_3));	INVX4 g2090(.IN (i_6_), .QN (n_12));
endmodule

