            path=@"e:\temp";
            
            OleDbConnection conn = new OleDbConnection(@"Provider = Microsoft.ACE.OLEDB.12.0; Data Source =" + path + "; Extended Properties ='Excel 12.0 Xml; HDR = YES';");
            OleDbDataAdapter adapter = new OleDbDataAdapter("select * from [Planilha1$]", conn);
            
            DataSet ds = new DataSet();
            conn.Open();
            adapter.Fill(ds);

            foreach (DataRow line in ds.Tables[0].Rows)
            {
                ScheduledMaintenance s = new ScheduledMaintenance();
                var date = line["Data Prevista"].ToString();
                if (date != "")
                {
                    s.Scheduled = Convert.ToDateTime(line["Data Prevista"].ToString());
                    s.Locomotive = line["Locomotiva"].ToString();
                    s.Observation = line["Observação"].ToString();
                    listScheduledMaintenance.Add(s);
                }
                else
                {
                    break;
                }
            }
            
