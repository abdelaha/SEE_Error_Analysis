
// n_6
module Cone_n_6 (n_6, i_4_, i_7_, i_8_ );
	input i_4_, i_7_, i_8_;
	output n_6;
	wire n_5;
	NAND2X2 g2081(.IN1 (n_5), .IN2 (i_8_), .QN (n_6));	ISOLANDX2 g2085(.ISO (i_4_), .D (i_7_), .Q (n_5));
endmodule

