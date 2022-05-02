// ���� ifdef ���Ǵ���ʹ�� DLL �������򵥵�
// ��ı�׼�������� DLL �е������ļ��������������϶���� DATAYESINTERFACE2_EXPORTS
// ���ű���ġ���ʹ�ô� DLL ��
// �κ�������Ŀ�ϲ�Ӧ����˷��š�������Դ�ļ��а������ļ����κ�������Ŀ���Ὣ
// DATAYESINTERFACE2_API ������Ϊ�Ǵ� DLL ����ģ����� DLL ���ô˺궨���
// ������Ϊ�Ǳ������ġ�
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
//API�ͻ���ʹ�ö��ֽ��ַ������룬���ù������£�
//menu-> Project -> Properties -> Configuration Properties -> General -> Character Set ����ΪUse Multi-Byte Character Set
#include "Windows.h"
#include "wininet.h"
#include <cstdio>
#include <string>
#include <iostream>
#include <cstdlib>
//������Ҫ wininet.lib
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

// �����Ǵ� DatayesInterface2.dll ������
class DATAYESINTERFACE2_API CDatayesInterface2 {
//public:
	//CDatayesInterface2(void);
	// TODO:  �ڴ�������ķ�����

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