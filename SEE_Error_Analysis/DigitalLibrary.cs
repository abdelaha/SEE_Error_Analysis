using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEE_Error_Analysis
{
    static class DigitalLibrary
    {
        public static bool MUX21(bool IN1, bool IN2, bool S)
        {
            if (S)
                return IN2;
            else
                return IN1;

        }


        public static bool AND4(bool IN1, bool IN2, bool IN3, bool IN4)
        {
            return IN1 & IN2 & IN3 & IN4;

        }
        public static bool AND3(bool IN1, bool IN2, bool IN3)
        {
            return IN1 & IN2 & IN3;

        }
        public static bool AND2(bool IN1, bool IN2)
        {
            return IN1 & IN2;

        }
        public static bool NAND4(bool IN1, bool IN2, bool IN3, bool IN4)
        {
            return !(IN1 & IN2 & IN3 & IN4);

        }

        public static bool NAND2(bool IN1, bool IN2)
        {
            return !(IN1 & IN2);

        }

        public static bool NAND3(bool IN1, bool IN2, bool IN3)
        {
            return !(IN1 & IN2 & IN3);

        }
        public static bool INV(bool IN)
        {
            return !IN;
        }

        public static bool NOR3(bool IN1, bool IN2, bool IN3)
        {
            return !(IN1 | IN2 | IN3);
        }

        public static bool NOR2(bool IN1, bool IN2)
        {
            return !(IN1 | IN2);
        }

        public static bool NOR4(bool IN1, bool IN2, bool IN3, bool IN4)
        {
            return !(IN1 | IN2 | IN3 | IN4);
        }

        public static bool OR3(bool IN1, bool IN2, bool IN3)
        {
            return (IN1 | IN2 | IN3);
        }
        public static bool OR4(bool IN1, bool IN2, bool IN3, bool IN4)
        {
            return (IN1 | IN2 | IN3 | IN4);
        }
        public static bool OR2(bool IN1, bool IN2)
        {
            return (IN1 | IN2);
        }

        public static bool OA222(bool IN1, bool IN2, bool IN3, bool IN4, bool IN5, bool IN6)
        {
            return ((IN1 | IN2) & (IN3 | IN4) & (IN5 | IN6));

        }
        public static bool OA221(bool IN1, bool IN2, bool IN3, bool IN4, bool IN5)
        {
            return ((IN1 | IN2) & (IN3 | IN4) & (IN5));

        }

        public static bool OA22(bool IN1, bool IN2, bool IN3, bool IN4)
        {
            return ((IN1 | IN2) & (IN3 | IN4));

        }


        public static bool OA21(bool IN1, bool IN2, bool IN3)
        {
            return ((IN1 | IN2) & (IN3));

        }


        public static bool OAI21(bool IN1, bool IN2, bool IN3)
        {
            return !((IN1 | IN2) & (IN3));

        }

        public static bool OAI22(bool IN1, bool IN2, bool IN3, bool IN4)
        {
            return !((IN1 | IN2) & (IN3 | IN4));

        }
        public static bool OAI221(bool IN1, bool IN2, bool IN3, bool IN4, bool IN5)
        {
            return !((IN1 | IN2) & (IN3 | IN4) & (IN5));

        }
        public static bool OAI222(bool IN1, bool IN2, bool IN3, bool IN4, bool IN5, bool IN6)
        {
            return !((IN1 | IN2) & (IN3 | IN4) & (IN5 | IN6));

        }

        public static bool AO21(bool IN1, bool IN2, bool IN3)
        {
            return ((IN1 & IN2) | (IN3));

        }

        public static bool AO22(bool IN1, bool IN2, bool IN3, bool IN4)
        {
            return ((IN1 & IN2) | (IN3 & IN4));

        }
        public static bool AO221(bool IN1, bool IN2, bool IN3, bool IN4, bool IN5)
        {
            return ((IN1 & IN2) | (IN3 & IN4) | (IN5));

        }
        public static bool AO222(bool IN1, bool IN2, bool IN3, bool IN4, bool IN5, bool IN6)
        {
            return ((IN1 & IN2) | (IN3 & IN4) | (IN5 & IN6));

        }

        public static bool AOI21(bool IN1, bool IN2, bool IN3)
        {
            return !((IN1 & IN2) | (IN3));

        }
        public static bool AOI22(bool IN1, bool IN2, bool IN3, bool IN4)
        {
            return !((IN1 & IN2) | (IN3 & IN4));

        }
        public static bool AOI221(bool IN1, bool IN2, bool IN3, bool IN4, bool IN5)
        {
            return !((IN1 & IN2) | (IN3 & IN4) | (IN5));

        }
        public static bool AOI222(bool IN1, bool IN2, bool IN3, bool IN4, bool IN5, bool IN6)
        {
            return !((IN1 & IN2) | (IN3 & IN4) | (IN5 & IN6));

        }
        public static bool ISOLAND(bool D, bool ISO)
        {
            return (D & !(ISO));

        }


        public static bool XNOR2(bool IN1, bool IN2)
        {
            return !(IN1 ^ IN2);

        }


        public static bool XNOR3(bool IN1, bool IN2, bool IN3)
        {
            return !(IN1 ^ IN2^ IN3);

        }
        
        public static bool XOR2(bool IN1, bool IN2)
        {
            return (IN1 ^ IN2);

        }


        public static int calculate_Parity(string GateName, int outputParity)
        {


            switch (GateName)
            {
                case "MUX21":
                    return outputParity;   //THis return shouldn't assign to selection input, the selectioin input has a binate parity
                // Gates with inversion value = 0
                case "AND4":
                case "AND3":
                case "AND2":
                case "OR3":
                case "OR4":
                case "OR2":
                case "OA222":
                case "OA221":
                case "OA22":
                case "OA21":
                case "AO21":
                case "AO22":
                case "AO221":
                case "AO222":
                case "ISOLAND":
                case "ISOLOR":
                    return outputParity;
                // Gates with inversion value = 1    
                case "NAND4":
                case "NAND2":
                case "NAND3":
                case "INV":
                case "NOR3":
                case "NOR4":
                case "NOR2":
                case "OAI21":
                case "OAI22":
                case "OAI221":
                case "OAI222":
                case "AOI21":
                case "AOI22":
                case "AOI221":
                case "AOI222":
                    return (outputParity ^ 1);



                default:
                    
                    return -2;

            }



        }

    }
}
