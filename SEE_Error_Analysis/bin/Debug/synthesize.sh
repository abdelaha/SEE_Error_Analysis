#/bin/sh
SYN_ID=$2
FILE=$1

SYN_TOOL=rc
ABC_TOOL=/home/abdelaha/ABCworkspace/abc-6144c8/abc
ABC_REPORT=/tmp/ABC.$SYN_ID.rpt



if [`echo $FILE | egrep .v$` ]; then

	FILE="$FILE"
else
$ABC_TOOL > ABC_LOG  << ABCEOF
read $FILE;
resyn2
write_verilog $FILE.v;
quit
ABCEOF
		FILE="$FILE.v"
fi


FILE_FORMAT=verilog
echo ${FILE}

RC_REPORT=/tmp/syn.$SYN_ID.rpt
AREA=/tmp/syn.$SYN_ID.area

$SYN_TOOL > $RC_REPORT << EOF
## Define the search path 
set_attribute lib_search_path /usr/local/isde/PDK/SAED/SAED_EDK90nm/Digital_Standard_Cell_Library/synopsys/models 


## This defines the library to use 
set_attribute library {saed90nm_typ.lib} 
## Read in verilog code for 8-bit accumulator 
read_hdl  $FILE

set_attribute avoid true LNANDX1 LNANDX2
## This creates a technology-independent schematic 

elaborate 

# 
# Set the time unit 
# 
#set_time_unit -nanoseconds 
# 
# Create a clock and use it to drive the clk pin 
# 
#create_clock -name {clk} -period 20.0 -waveform {0.0 10.0} [get_ports {clk}] 
# 
# Don't optimize the reset 
# 
#set_false_path -from [get_ports {reset}] 

set_attribute wireload_mode top /
set_attribute operating_conditions _nominal_ /

## This is where you can put in non-timing related constraints 
##set_attribute avoid true FAX1 
## Create a techonology-dependent schematic
set_attribute dp_area_mode true /
set incremental_opto 0 
synthesize -to_generic
synthesize -to_mapped 
synthesize -to_mapped 
synthesize -to_mapped
synthesize -to_mapped 
set global_area 1
set max_area 0
set area_down 1
synthesize -to_mapped -effort high
## Write out synthesized verilog netlist 
write_hdl -mapped > /tmp/syn.$SYN_ID.v 
 


# Reports
echo "*******************"
echo "*** AREA REPORT ***"
echo "*******************"
report gates $top_level
echo [get_attribute area /designs/*]> $AREA
echo "*********************"
echo "*** TIMING REPORT ***"
echo "*********************"
report timing

quit
EOF

#tac $RC_REPORT | grep -m1 init_area | awk  '{print $2}' > $AREA

rm rc.lo*
rm rc.cm*
