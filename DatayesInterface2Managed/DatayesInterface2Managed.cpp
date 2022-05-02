// 这是主 DLL 文件。

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
		// 在析构函数中删除CPerson对象
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

	/* 设置token*/
	int CDataClient::init(String^  APIToken){
		// 将string转换成C++能识别的指针
		//pin_ptr<const wchar_t> newAPIToken = PtrToStringChars(APIToken); 

		std::string newAPIToken;
		//System::String^ myManagedString = "My test string";
		ConvertManagedStringToStdString(newAPIToken, APIToken);

		m_pImp->init(newAPIToken);

		//System::String ^ str = "Hello world\n";

		//// 为了可以打印wstring到控制台  
		//std::wcout.imbue(std::locale("chs"));

		//// 声明两个string  
		//std::string strOld = "阿里路亚!"; //std的string  
		//String^ strNew = "耶稣基督!"; //cli的string.  

		////std::string转cli的string  
		//String^ stdToCli = marshal_as<String^>(strOld);
		//Console::WriteLine(stdToCli);

		////cli的string转std::string  
		//std::string cliToStd = marshal_as<std::string>(strNew);
		//std::cout << cliToStd << std::endl;

		////cli的string转std::wstring  
		//std::wstring cliToWstring = marshal_as<std::wstring>(strNew);
		//std::wcout << cliToWstring << std::endl;

		return 1;
	}

	//151126:这个函数因为参数传递字符串搞不定，放弃。String^<->std::string之间的转换太复杂，不搞了。用返回字符串的形式实现
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

