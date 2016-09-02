using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractService;
using LoggingServiceModel;
using System.IO;

namespace LoggingService
{
	public class LogListener : IMessageEventHandler<LogMessage>
	{
		StreamWriter log;

		public LogListener()
		{
			log = new StreamWriter(Config.LogFileName);
			log.Write(Config.InitialLogText);
		}
		public void close()
		{
			log.Close();
		}
		public void  onMessage(LogMessage message)
		{
			string logType = LogMessage.LogTypeMap[message.MessageType];
			string logStr = String.Format("{0} :     {1} :    {2}", logType, message.ServiceName, message.Message);
			log.WriteLine(logStr);
			Console.WriteLine(logStr);
		}
	}
}
