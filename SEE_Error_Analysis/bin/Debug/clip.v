
module \clip.pla  ( i_0_, i_1_, i_2_, i_3_, i_4_, i_5_, i_6_, i_7_, i_8_, o_0_, 
        o_1_, o_2_, o_3_, o_4_ );
  input i_0_, i_1_, i_2_, i_3_, i_4_, i_5_, i_6_, i_7_, i_8_;
  output o_0_, o_1_, o_2_, o_3_, o_4_;
  wire   net_152, net_153, net_154, net_155, net_156, net_157, net_158,
         net_159, net_160, net_161, net_162, net_163, net_164, net_165,
         net_166, net_167, net_168, net_169, net_170, net_171, net_172,
         net_173, net_174, net_175, net_176, net_177, net_178, net_179,
         net_180, net_181, net_182, net_183, net_184, net_185, net_186,
         net_187, net_188, net_189, net_190, net_191, net_192, net_193,
         net_194, net_195, net_196, net_197, net_198, net_199, net_200;

  NAND2X0 U112 ( .IN1(net_152), .IN2(net_153), .QN(o_3_) );
  NAND2X0 U113 ( .IN1(o_4_), .IN2(net_154), .QN(net_153) );
  AO22X1 U114 ( .IN1(i_5_), .IN2(net_155), .IN3(net_156), .IN4(i_6_), .Q(o_4_)
         );
  NOR2X0 U115 ( .IN1(i_0_), .IN2(net_157), .QN(net_156) );
  NAND3X0 U116 ( .IN1(i_0_), .IN2(net_158), .IN3(net_159), .QN(net_155) );
  MUX21X1 U117 ( .IN1(net_160), .IN2(net_161), .S(net_158), .Q(net_152) );
  MUX21X1 U118 ( .IN1(net_162), .IN2(net_163), .S(net_164), .Q(net_161) );
  NOR2X0 U119 ( .IN1(net_154), .IN2(net_163), .QN(net_162) );
  INVX0 U120 ( .IN(net_159), .QN(net_163) );
  NAND3X0 U121 ( .IN1(net_165), .IN2(net_166), .IN3(i_0_), .QN(net_160) );
  NAND2X0 U122 ( .IN1(net_167), .IN2(net_168), .QN(o_2_) );
  MUX21X1 U123 ( .IN1(net_169), .IN2(net_170), .S(i_6_), .Q(net_167) );
  OA21X1 U124 ( .IN1(net_171), .IN2(net_172), .IN3(net_166), .Q(net_170) );
  NAND2X0 U125 ( .IN1(net_173), .IN2(net_174), .QN(net_166) );
  MUX21X1 U126 ( .IN1(net_175), .IN2(net_176), .S(net_171), .Q(net_173) );
  NAND2X0 U127 ( .IN1(net_177), .IN2(net_178), .QN(o_0_) );
  NAND2X0 U128 ( .IN1(net_159), .IN2(net_179), .QN(net_178) );
  OA21X1 U129 ( .IN1(net_169), .IN2(net_176), .IN3(net_180), .Q(net_159) );
  XOR2X1 U130 ( .IN1(net_181), .IN2(net_182), .Q(net_169) );
  OA21X1 U131 ( .IN1(o_1_), .IN2(net_183), .IN3(net_184), .Q(net_182) );
  NAND3X0 U132 ( .IN1(net_185), .IN2(net_186), .IN3(net_187), .QN(o_1_) );
  NAND3X0 U133 ( .IN1(net_188), .IN2(net_189), .IN3(net_190), .QN(net_185) );
  NAND2X0 U134 ( .IN1(i_1_), .IN2(net_191), .QN(net_189) );
  MUX21X1 U135 ( .IN1(net_192), .IN2(net_193), .S(i_1_), .Q(net_177) );
  OA21X1 U136 ( .IN1(i_2_), .IN2(net_194), .IN3(net_187), .Q(net_193) );
  NAND2X0 U137 ( .IN1(net_179), .IN2(net_195), .QN(net_187) );
  OR3X1 U138 ( .IN1(net_190), .IN2(i_4_), .IN3(net_176), .Q(net_195) );
  INVX0 U139 ( .IN(net_181), .QN(net_176) );
  OA21X1 U140 ( .IN1(net_196), .IN2(net_197), .IN3(net_180), .Q(net_181) );
  INVX0 U141 ( .IN(net_168), .QN(net_179) );
  NAND4X0 U142 ( .IN1(i_0_), .IN2(net_180), .IN3(net_154), .IN4(net_158), .QN(
        net_168) );
  INVX0 U143 ( .IN(i_5_), .QN(net_154) );
  NAND2X0 U144 ( .IN1(net_197), .IN2(net_196), .QN(net_180) );
  INVX0 U145 ( .IN(i_8_), .QN(net_197) );
  INVX0 U146 ( .IN(net_188), .QN(net_194) );
  AO21X1 U147 ( .IN1(net_190), .IN2(net_198), .IN3(net_174), .Q(net_188) );
  NAND2X0 U148 ( .IN1(i_2_), .IN2(net_198), .QN(net_192) );
  OR2X1 U149 ( .IN1(net_174), .IN2(net_157), .Q(net_198) );
  ISOLANDX1 U150 ( .D(net_165), .ISO(net_175), .Q(net_157) );
  NOR2X0 U151 ( .IN1(net_196), .IN2(i_8_), .QN(net_175) );
  NAND2X0 U152 ( .IN1(net_171), .IN2(net_172), .QN(net_165) );
  NAND2X0 U153 ( .IN1(net_186), .IN2(net_199), .QN(net_171) );
  NAND4X0 U154 ( .IN1(i_1_), .IN2(net_191), .IN3(net_174), .IN4(net_183), .QN(
        net_186) );
  INVX0 U155 ( .IN(net_190), .QN(net_183) );
  OA21X1 U156 ( .IN1(i_4_), .IN2(i_7_), .IN3(net_184), .Q(net_190) );
  NAND2X0 U157 ( .IN1(i_4_), .IN2(net_199), .QN(net_184) );
  NAND2X0 U158 ( .IN1(i_4_), .IN2(net_200), .QN(net_199) );
  INVX0 U159 ( .IN(i_7_), .QN(net_200) );
  XNOR2X1 U160 ( .IN1(i_2_), .IN2(net_158), .Q(net_191) );
  INVX0 U161 ( .IN(i_6_), .QN(net_158) );
  NAND4X0 U162 ( .IN1(i_6_), .IN2(i_5_), .IN3(net_172), .IN4(net_164), .QN(
        net_174) );
  INVX0 U163 ( .IN(i_0_), .QN(net_164) );
  NAND2X0 U164 ( .IN1(i_8_), .IN2(net_196), .QN(net_172) );
  INVX0 U165 ( .IN(i_3_), .QN(net_196) );
endmodule

