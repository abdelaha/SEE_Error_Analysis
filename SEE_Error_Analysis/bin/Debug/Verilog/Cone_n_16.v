
// n_16
module Cone_n_16 (n_16, i_5_, i_6_, i_0_ );
	input i_5_, i_6_, i_0_;
	output n_16;
	wire n_4, n_12;
	NAND3X2 g2083(.IN1 (n_4), .IN2 (n_12), .IN3 (i_0_), .QN (n_16));	INVX2 g2089(.IN (i_5_), .QN (n_4));	INVX4 g2090(.IN (i_6_), .QN (n_12));
endmodule

