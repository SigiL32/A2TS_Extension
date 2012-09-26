using System;
using System.Text;
using System.Net.Sockets;
using ArmA2;

namespace A2TS_ExtensionUDP
{
    public class A2TS_Init : IExtension
    {
        public string Call(String args)
        {
            // This function initializes everything else.

            return "hint 'A2TS: Extension initialized successfully.'";
        }
    }

    public class A2TS_SendUdp : IExtension
    {
        public string Call(String udpMessageContent)
        {
            // This method sends a udp message;

            return "hint 'A2TS: Attempting to send message. Message content: " + udpMessageContent + "'";
        }
    }

    public class A2TS_ReceiveUdp : IExtension
    {
        public string Call(String arg)
        {
            // This method receives udp messages;
            return "hint 'A2TS: Received a message. Message content: ";
        }
    }

    /*****************************************************************************************************/

    public class A2TS_udpClient
    {
        UdpClient _udpSender;

        public string Init()
        {
            try
            {
                _udpSender = new UdpClient(55554);
                _udpSender.Connect("localhost", 55555);
                return "";
            }
            catch (Exception ex)
            {
                return "hint 'Failure creating a UDP client. Reason: " + ex.Message + "'";
            }
        }

        public string Send(String dataToSend)
        {
            try
            {
                byte[] bytesToSend = Encoding.ASCII.GetBytes(dataToSend);
                _udpSender.Send(bytesToSend, bytesToSend.Length);
                return "";
            }
            catch (Exception ex)
            {
                return "hint 'Failed to send UDP message. Reason: " + ex.Message + "'";
            }
        }

        public string Receive(String commandToSend)
        {
            try
            {
                // Send a command to the plug-in.
                byte[] bytesToSend = Encoding.ASCII.GetBytes(commandToSend);
                _udpSender.Send(bytesToSend, bytesToSend.Length);

                // Await a reply from it.
                

                //_udpSender.Receive

            }
            catch (Exception ex)
            {
                return "hint 'Failed to receive UDP message. Reason: " + ex.Message + "'"; 
            }
        }
    }



}
