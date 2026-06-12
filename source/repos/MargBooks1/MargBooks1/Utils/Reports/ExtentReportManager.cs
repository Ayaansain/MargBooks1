using System;
using System.IO;

namespace MargBooks1.Utils.Reports
{
    public static class ReportManager
    {
        private static string reportPath =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
            "Reports", "Report.html");

        public static void InitReport()
        {
            // Reports folder create
            Directory.CreateDirectory(
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reports"));

            // Basic HTML Start
            File.WriteAllText(reportPath,
            @"<html>
              <head>
                    <title>Automation Report</title>
                    <style>
                        body{
                            font-family: Arial;
                            background:#f4f4f4;
                            padding:20px;
                        }

                        h1{
                            color:#333;
                        }

                        table{
                            width:100%;
                            border-collapse:collapse;
                            background:white;
                        }

                        th,td{
                            border:1px solid #ddd;
                            padding:10px;
                            text-align:left;
                        }

                        th{
                            background:#0078D7;
                            color:white;
                        }

                        .pass{
                            color:green;
                            font-weight:bold;
                        }

                        .fail{
                            color:red;
                            font-weight:bold;
                        }
                    </style>
              </head>
              <body>

              <h1>Automation Execution Report</h1>

              <table>
                    <tr>
                        <th>Time</th>
                        <th>Test Case</th>
                        <th>Status</th>
                        <th>Message</th>
                    </tr>");
        }

        public static void Log(string testName, string status, string message)
        {
            string cssClass = status.ToLower() == "pass" ? "pass" : "fail";

            string row = $@"
                <tr>
                    <td>{DateTime.Now}</td>
                    <td>{testName}</td>
                    <td class='{cssClass}'>{status}</td>
                    <td>{message}</td>
                </tr>";

            File.AppendAllText(reportPath, row);
        }

        public static void FlushReport()
        {
            File.AppendAllText(reportPath,
            @"</table>
              </body>
              </html>");
        }
    }
}