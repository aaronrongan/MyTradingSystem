// DatayesInterface2Managed.h

#pragma once
//#include "C:\MyDocuments\我的坚果云\MyProjects\MyTradingSystem\DatayesInterface2\DatayesInterface2\DatayesInterface2.h"
//#include "DatayesInterface2.h"
#include <vcclr.h>
#include "DatayesInterface2.h"
#define LX_DLL_CLASS_EXPORTS


using namespace System; 



//<DllImport(\"Data.dll\")> 
//Private Shared Function ConnectPlayServer(ByVal Address As String, ByVal Port As Integer, ByVal DataPort As Integer, ByVal Username As String) As Boolean 
//
//	End Function
//	Private Declare Auto Function a Lib \"Lib.dll\" (ByVal i As Integer) As String2.

namespace DatayesInterface2Managed {

	public ref class CDataClient
	{
		// TODO:  在此处添加此类的方法。
	public:
		int init(String ^ APIToken);
		int getData_obsolete(String^ URL, String^ Result);
		String^ getData(String^ URL);

		//int getData(String^ URL, char* Result);
		CDataClient();
		~CDataClient();
	private:
		CDatayesInterface2 *m_pImp;

		//static void ConvertManagedStringToStdString(std::string &outStr, String ^str);
		//void U2G(const char* utf8, string& re);
		//LPCTSTR serverDomain;
		//string token;
		//System::String token;
		//String^ token;
		//string token;
		//LPCTSTR lpszVerb;
		//INTERNET_PORT port;
		//LPCTSTR lpszAgent;
		//HINTERNET hInternet;
		//HINTERNET hConnect;
	};
}
