// 下列 ifdef 块是创建使从 DLL 导出更简单的
// 宏的标准方法。此 DLL 中的所有文件都是用命令行上定义的 DATAYESINTERFACE2_EXPORTS
// 符号编译的。在使用此 DLL 的
// 任何其他项目上不应定义此符号。这样，源文件中包含此文件的任何其他项目都会将
// DATAYESINTERFACE2_API 函数视为是从 DLL 导入的，而此 DLL 则将用此宏定义的
// 符号视为是被导出的。
#ifdef DATAYESINTERFACE2_EXPORTS
#define DATAYESINTERFACE2_API __declspec(dllexport)
#else
#define DATAYESINTERFACE2_API __declspec(dllimport)
#endif


////public ref class CDatayesInterface2
//class CDatayesInterface2
//{
//public:
//	int init(string& APIToken);
//	int getData(string& URL, string& Result);
//	CDatayesInterface2();
//	~CDatayesInterface2();
//private:
//	void U2G(const char* utf8, string& re);
//	LPCTSTR serverDomain;
//	//string token;
//	/*System::String token;*/
//	string token;
//	LPCTSTR lpszVerb;
//	INTERNET_PORT port;
//	LPCTSTR lpszAgent;
//	HINTERNET hInternet;
//	HINTERNET hConnect;
//};

extern DATAYESINTERFACE2_API int nDatayesInterface2;

DATAYESINTERFACE2_API int fnDatayesInterface2(void);

/////////////////////////////////////
#pragma once
/////////////////////////////////////////////////
//API客户端使用多字节字符集编码，设置过程如下：
//menu-> Project -> Properties -> Configuration Properties -> General -> Character Set 设置为Use Multi-Byte Character Set
#include "Windows.h"
#include "wininet.h"
#include <cstdio>
#include <string>
#include <iostream>
#include <cstdlib>
//链接需要 wininet.lib
#pragma comment(lib,"wininet.lib")
using namespace std;
//what retCode
#define RETCODE_SUCC 1
#define RETCODE_FAILED 0
#define RETCODE_NORST -1
#define RETCODE_BADREQ -2
#define RETCODE_SERVSTOP -3
#define RETCODE_UNKNOWN -4
#define RETCODE_BUSY -5
#define RETCODE_AUTHENTICATION_FAILED -6

//what retMsg
#define RETMSG_SUCC "Success"
#define RETMSG_FAILED "Failed"
#define RETMSG_NORST "No Data Returned"
#define RETMSG_BADREQ "Illegal Request Parameter"
#define RETMSG_SERVSTOP "Service Suspend"
#define RETMSG_UNKNOWN "Internal server Error"
#define RETMSG_BUSY "Server Busy"

#define BUFFERSIZE 16384 //16k

// 此类是从 DatayesInterface2.dll 导出的
class DATAYESINTERFACE2_API CDatayesInterface2 {
//public:
	//CDatayesInterface2(void);
	// TODO:  在此添加您的方法。

public:
	int init(string& APIToken);
	int getData(string& URL, string& Result);
	CDatayesInterface2();
	~CDatayesInterface2();
private:
	void U2G(const char* utf8, string& re);
	LPCTSTR serverDomain;
	//string token;
	/*System::String token;*/
	string token;
	LPCTSTR lpszVerb;
	INTERNET_PORT port;
	LPCTSTR lpszAgent;
	HINTERNET hInternet;
	HINTERNET hConnect;

};