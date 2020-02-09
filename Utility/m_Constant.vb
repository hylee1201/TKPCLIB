Module m_Constant
    'Public Const MDB_CONSTR = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\temp\TKPC.mdb"
    'Public Const SQL_CONSTR = "Data Source=YOUR-4105E587B6\SQLEXPRESS;Initial Catalog=TKPC;Integrated Security=True"
    'Public Const SQL_CONSTR = "Data Source=ADMIN-PC\TKPCDB;Initial Catalog=TKPC;Integrated Security=False;User Id=sa;Password=sa123"
    Public Const SQL_CONSTR = "Data Source=ADMIN-PC\SQLEXPRESS;Initial Catalog=TKPC;Integrated Security=True"
    'Public Const SQL_CONSTR = "Server=.\SQLExpress;AttachDbFilename=C:\Users\Public\TKPC.mdf;Database=TKPC;Trusted_Connection=Yes"
    'Public Const SQL_CONSTR2 = "DSN=BTICustomer;uid=btieng;pwd=bomimport;" '"Data Source=QBUILD-09DE2A84\sqlexpress;Initial Catalog=BTI_Systems;Integrated Security=True"
    'Public Const EXCEL_CONSTR = "Provider=Microsoft.Jet.OLEDB.4.0;Extended Properties=Excel 8.0;Data Source="

    Public Const VIEW_MODE_ADD_NEW = 0
    Public Const VIEW_MODE_DETAIL = 1
    Public Const VIEW_MODE_ADD_MORE = 2
    Public Const VIEW_MODE_DUPLICATE = 3

    Public Const BOOK_LIST_EXCEL = "newBookList.xls"
    Public Const BOOL_LIST_AT_RENT_EXCEL = "bookListAtRent.xls"
    Public Const PERSON_LIST_EXCEL = "personList.xls"
    Public Const RENT_LIST_EXCEL = "rentList.xls"
    Public Const RESERVE_LIST_EXCEL = "reserveList.xls"

    Public Const WHOLE_LIST = 0
    Public Const PARTIAL_LIST1 = 1
    Public Const PARTIAL_LIST2 = 2
    Public Const PARTIAL_LIST3 = 3
    Public Const PARTIAL_LIST4 = 4
    Public Const PARTIAL_LIST5 = 5
    Public Const PARTIAL_LIST6 = 6
    Public Const PARTIAL_LIST7 = 7
    Public Const PARTIAL_LIST8 = 8

    Public Const FROM_BOOK_LIST_OR_MDI = 0
    Public Const FROM_RENT_ADD = 1
    Public Const FROM_PERSON_ADD = 2
    Public Const FROM_RETURN_ADD = 3

    Public Const TEL_REGEX = "^([0-9]{3}-)?[0-9]{3}-\d{4}$"  'Canadian
    Public Const BARCODE_REGEX = "[0-9]+-[0-9]{5}"
    Public Const ZIP_WITH_SPACE_REGEX = "(^[A-Z]{1}\d{1}[A-Z]{1} \d{1}[A-Z]{1}\d{1}$)" 'Canadian
    Public Const ZIP_WITHOUT_SPACE_REGEX = "(^[A-Z]{1}\d{1}[A-Z]{1}\d{1}[A-Z]{1}\d{1}$)" 'Canadian
    Public Const EMAIL_REGEX = "^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"

    '"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+(?:[A-Z]{2}|com|org|net|gov|mil|biz|info|mobi|name|aero|jobs|museum)\b"

    Public Const PERSON_FLAG = "P"
    Public Const BOOK_FLAG = "B"

    Public Const REVOKE_TRUE = 1
    Public Const REVOKE_FALSE = 0

    Public Const KbdKr = "00000412"  'Korean (standard)'//by default installed
    'Public Const KbdKr =  "00000012"  'Korean (standard)'//by default installed
    Public Const KbdEn = "00000409"  'English(US)   '//by default installed

    Public Const BOOK_STATUS_A = "A" 'Available
    Public Const BOOK_STATUS_R = "R" 'Rented
    Public Const BOOK_STATUS_L = "L" 'Lost

    Public Const BOOK_TYPE_PURCHASE = "P"
    Public Const BOOK_TYPE_DONATE = "D"

    Public Const MEMO_TYPE_BOOK = "Book"
    Public Const MEMO_TYPE_BARCODE = "Barcode"
End Module
