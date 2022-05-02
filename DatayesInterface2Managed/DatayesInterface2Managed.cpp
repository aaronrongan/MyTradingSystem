// ������ DLL �ļ���

#include "stdafx.h"
#include "DatayesInterface2Managed.h"
#include <msclr\marshal_cppstd.h> 
#include <string>
#include <iostream>

#include <msclr/marshal.h>

using namespace msclr::interop;

namespace DatayesInterface2Managed {


	CDataClient::CDataClient()
	{
		m_pImp = new CDatayesInterface2();
	}

	CDataClient::~CDataClient(){
		// ������������ɾ��CPerson����
		delete m_pImp;
	}

	static void ConvertManagedStringToStdString(std::string &outStr, String ^str)
	{
		IntPtr ansiStr = System::Runtime::InteropServices::Marshal::StringToHGlobalAnsi(str);
		outStr = (const char*)ansiStr.ToPointer(); 
		System::Runtime::InteropServices::Marshal::FreeHGlobal(ansiStr);
	}

	static void ConvertStdStringToManagedString(std::string &outStr, String^ str)
	{
		//IntPtr ansiStr = System::Runtime::InteropServices::Marshal::StringToHGlobalAnsi(str);
		//outStr = (const char*)ansiStr.ToPointer(); 

		//str = marshal_context.marshal_as<String^>(outStr);

		//const char* tempString = const_cast<char*>(outStr);

		//str = System::Runtime::InteropServices::Marshal::PtrToStringAnsi(static_cast<IntPtr>(outStr));

		//str = marshal_as<String^>(outStr);

		//str = gcnew String(outStr.c_str());

		//str = (const char*)ansiStr.ToPointer();
		//System::Runtime::InteropServices::Marshal::FreeHGlobal(ansiStr);

		//str = new String(outStr.c_str());
	}

	/* ����token*/
	int CDataClient::init(String^  APIToken){
		// ��stringת����C++��ʶ���ָ��
		//pin_ptr<const wchar_t> newAPIToken = PtrToStringChars(APIToken); 

		std::string newAPIToken;
		//System::String^ myManagedString = "My test string";
		ConvertManagedStringToStdString(newAPIToken, APIToken);

		m_pImp->init(newAPIToken);

		//System::String ^ str = "Hello world\n";

		//// Ϊ�˿��Դ�ӡwstring������̨  
		//std::wcout.imbue(std::locale("chs"));

		//// ��������string  
		//std::string strOld = "����·��!"; //std��string  
		//String^ strNew = "Ү�ջ���!"; //cli��string.  

		////std::stringתcli��string  
		//String^ stdToCli = marshal_as<String^>(strOld);
		//Console::WriteLine(stdToCli);

		////cli��stringתstd::string  
		//std::string cliToStd = marshal_as<std::string>(strNew);
		//std::cout << cliToStd << std::endl;

		////cli��stringתstd::wstring  
		//std::wstring cliToWstring = marshal_as<std::wstring>(strNew);
		//std::wcout << cliToWstring << std::endl;

		return 1;
	}

	//151126:���������Ϊ���������ַ����㲻����������String^<->std::string֮���ת��̫���ӣ������ˡ��÷����ַ�������ʽʵ��
	int CDataClient::getData_obsolete(String^ URL, String^ Result){
		//int CDataClient::getData(String^ URL, char* Result){

		std::string newURL, newResult;
		//std::string newResult1(Result);
		//long charlen;

		ConvertManagedStringToStdString(newURL, URL);

		m_pImp->getData(newURL, newResult);

		ConvertStdStringToManagedString(newResult, Result);

		String^ Result1 = gcnew String(newResult.c_str());
		//Result ="2000";
		//charnumbers = 10;
		//ConvertManagedStringToStdString(newResult, Result);

		//ConvertManagedStringToStdString(newResult, Result);
		//return (int&)newResult;
		return 1;
	}

	String^ CDataClient::getData(String^ URL){
	
		std::string newURL, newResult;
	
		ConvertManagedStringToStdString(newURL, URL);

		m_pImp->getData(newURL, newResult);

		String^ Result1 = gcnew String(newResult.c_str());
		return Result1;

		//ConvertStdStringToManagedString(newResult, Result);

		//int CDataClient::getData(String^ URL, char* Result){

		//Result ="2000";
		//charnumbers = 10;
		//ConvertManagedStringToStdString(newResult, Result);

		//ConvertManagedStringToStdString(newResult, Result);
		//return (int&)newResult;
		
	}

}

