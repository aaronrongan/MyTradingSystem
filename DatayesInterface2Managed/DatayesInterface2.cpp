// DatayesInterface2.cpp : 定义 DLL 应用程序的导出函数。
//

#include "stdafx.h"
#include "DatayesInterface2.h"


//// 这是导出变量的一个示例
//DATAYESINTERFACE2_API int nDatayesInterface2=0;
//
//// 这是导出函数的一个示例。
//DATAYESINTERFACE2_API int fnDatayesInterface2(void)
//{
//	return 42;
//}
//
//// 这是已导出类的构造函数。
//// 有关类定义的信息，请参阅 DatayesInterface2.h
////CDatayesInterface2::CDatayesInterface2()
////{
////	return;
////}



CDatayesInterface2::CDatayesInterface2()
{
	lpszAgent = "WinInetGet/0.1";
	hInternet = InternetOpen(lpszAgent, INTERNET_OPEN_TYPE_PRECONFIG, NULL, NULL, 0);
	lpszVerb = "GET";
	serverDomain = "api.wmcloud.com";
	port = 443;
}

CDatayesInterface2::~CDatayesInterface2(){
	InternetCloseHandle(hInternet);
	InternetCloseHandle(hConnect);
}

/* 设置token*/
int CDatayesInterface2::init(string& APIToken){
	token = APIToken;
	hConnect = InternetConnect(hInternet, serverDomain, port, NULL, NULL, INTERNET_SERVICE_HTTP, 0, 0);
	if (hConnect == NULL){
		return GetLastError();
	}
	return 1;
}
int CDatayesInterface2::getData(string& URL, string& Result){
	Result = "";
	URL = "/data/v1" + URL;
	LPCTSTR lpszObjectName = URL.c_str();
	DWORD dwOpenRequestFlags = INTERNET_FLAG_IGNORE_REDIRECT_TO_HTTP |
		INTERNET_FLAG_KEEP_CONNECTION |
		INTERNET_FLAG_NO_AUTH |
		INTERNET_FLAG_NO_COOKIES |
		INTERNET_FLAG_NO_UI |
		//设置启用HTTPS
		INTERNET_FLAG_SECURE |
		INTERNET_FLAG_RELOAD;

	//初始化Request
	string Authheader = "Authorization: Bearer " + token;
	HINTERNET hRequest = HttpOpenRequest(hConnect, lpszVerb, lpszObjectName, NULL,
		NULL, NULL,
		dwOpenRequestFlags, 0);
	HttpAddRequestHeaders(hRequest, Authheader.c_str(), -1, HTTP_ADDREQ_FLAG_ADD | HTTP_ADDREQ_FLAG_REPLACE);
	//发送Request
	BOOL bResult = HttpSendRequest(hRequest, NULL, 0, NULL, 0);
	//链接失败，对应的错误码可以从微软网站http://support.microsoft.com/kb/193625 查询
	if (!bResult) {
		return GetLastError();
	}
	DWORD httpcode;
	DWORD dwSizeOfRq = sizeof(DWORD);
	HttpQueryInfo(hRequest, HTTP_QUERY_STATUS_CODE | HTTP_QUERY_FLAG_NUMBER, &httpcode, &dwSizeOfRq, NULL);
	//获取HTTP Response 的 Body.
	bool needconvert = true;
	if (URL.find(".csv?") != URL.npos)
		needconvert = false;
	DWORD dwBytesAvailable;
	//BYTE *pMessageBody = (BYTE *)malloc(BUFFERSIZE);
	BYTE messageBody[BUFFERSIZE];
	while (InternetQueryDataAvailable(hRequest, &dwBytesAvailable, 0, 0)) {
		DWORD dwBytesRead;
		BOOL bResult = InternetReadFile(hRequest, messageBody,
			dwBytesAvailable, &dwBytesRead);
		if (!bResult) {
			return RETCODE_FAILED;
		}
		if (dwBytesRead == 0)
			break;
		messageBody[dwBytesRead] = '\0';
		if (needconvert)
			U2G((char*)messageBody, Result);
		else
			Result += (char*)messageBody;
	}
	//根据返回信息，判断返回码
	if (httpcode == HTTP_STATUS_DENIED)
		return RETCODE_AUTHENTICATION_FAILED;
	//处理新闻API返回值
	if (URL.find("/news/") != URL.npos){
		//能够访问到API服务器
		if (httpcode >= 200 && httpcode<300){
			int pos = Result.find("code") + 6;
			int code = 0;
			int flag = 1;
			if (Result[pos] == '-'){
				flag = -1;
				pos++;
			}
			while (Result[pos] != ',')code = code * 10 + Result[pos++] - '0';
			code *= flag;
			return code;
		}
		return httpcode;
	}
	//处理其他API返回值
	if (httpcode >= 200 && httpcode<300){
		string resulthead = Result.substr(0, 100);
		if (resulthead.find(RETMSG_NORST) != resulthead.npos)
			return RETCODE_NORST;
		if (resulthead.find(RETMSG_BADREQ) != resulthead.npos)
			return RETCODE_BADREQ;
		if (resulthead.find(RETMSG_SERVSTOP) != resulthead.npos)
			return RETCODE_SERVSTOP;
		if (resulthead.find(RETMSG_UNKNOWN) != resulthead.npos)
			return RETCODE_UNKNOWN;
		if (resulthead.find(RETMSG_BUSY) != resulthead.npos)
			return RETCODE_BUSY;
		return RETCODE_SUCC;
	}
	return httpcode;
	
}
//UTF-8到GB2312的转换，json格式和新闻API都是UTF-8格式，需要转为GB2312；csv格式直接是GB2312，不需要转化。
void CDatayesInterface2::U2G(const char* utf8, string& re)
{
	int len = MultiByteToWideChar(CP_UTF8, 0, utf8, -1, NULL, 0);
	wchar_t* wstr = new wchar_t[len + 1];
	memset(wstr, 0, len + 1);
	MultiByteToWideChar(CP_UTF8, 0, utf8, -1, wstr, len);
	len = WideCharToMultiByte(CP_ACP, 0, wstr, -1, NULL, 0, NULL, NULL);
	char* str = new char[len + 1];
	memset(str, 0, len + 1);
	WideCharToMultiByte(CP_ACP, 0, wstr, -1, str, len, NULL, NULL);
	if (wstr) delete[] wstr;
	re += str;
	if (str) delete[] str;
}