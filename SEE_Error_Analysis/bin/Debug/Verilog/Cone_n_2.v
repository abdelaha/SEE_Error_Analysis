
// n_2
module Cone_n_2 (n_2, i_1_, i_2_ );
	input i_1_, i_2_;
	output n_2;
	NAND2X1 g2086(.IN1 (i_1_), .IN2 (i_2_), .QN (n_2));
endmodule

