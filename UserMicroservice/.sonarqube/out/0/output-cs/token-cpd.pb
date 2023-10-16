≈
}C:\Users\921611\source\repos\Clinic Visit Appointment Booking System\UserMicroservice\DataAccessLayer\CustomDateSerializer.cs
	namespace 	
DataAccessLayer
 
{ 
public		 

class		  
CustomDateSerializer		 %
:		& '
SerializerBase		( 6
<		6 7
DateTime		7 ?
>		? @
{

 
public 
override 
void 
	Serialize &
(& '$
BsonSerializationContext' ?
context@ G
,G H!
BsonSerializationArgsI ^
args_ c
,c d
DateTimee m
valuen s
)s t
{ 	
context 
. 
Writer 
. 
WriteString &
(& '
value' ,
., -
ToString- 5
(5 6
$str6 B
)B C
)C D
;D E
} 	
public 
override 
DateTime  
Deserialize! ,
(, -&
BsonDeserializationContext- G
contextH O
,O P#
BsonDeserializationArgsQ h
argsi m
)m n
{ 	
if 
( 
context 
. 
Reader 
. 
CurrentBsonType .
==/ 1
BsonType2 :
.: ;
String; A
)A B
{ 
string 
dateStr 
=  
context! (
.( )
Reader) /
./ 0

ReadString0 :
(: ;
); <
;< =
if 
( 
DateTime 
. 
TryParseExact *
(* +
dateStr+ 2
,2 3
$str4 @
,@ A
nullB F
,F G
SystemH N
.N O
GlobalizationO \
.\ ]
DateTimeStyles] k
.k l
Nonel p
,p q
outr u
DateTimev ~
dateTime	 á
)
á à
)
à â
{ 
return 
dateTime #
;# $
} 
} 
throw 
new 
FormatException %
(% &
$str& ;
); <
;< =
} 	
} 
} µ
ÇC:\Users\921611\source\repos\Clinic Visit Appointment Booking System\UserMicroservice\DataAccessLayer\DataBase\DataBaseSettings.cs
	namespace 	
DataAccessLayer
 
. 
DataBase "
{ 
public		 

class		 
DataBaseSettings		 !
:		! "
IDataBaseSettings		" 3
{

 
public 
required 
string  
ClinicCollectionName 3
{4 5
get6 9
;9 :
set; >
;> ?
}@ A
public 
required 
string 
ConnectionString /
{0 1
get2 5
;5 6
set7 :
;: ;
}< =
public 
required 
string 
DatabaseName +
{, -
get. 1
;1 2
set3 6
;6 7
}8 9
} 
} À
ÉC:\Users\921611\source\repos\Clinic Visit Appointment Booking System\UserMicroservice\DataAccessLayer\DataBase\IDataBaseSettings.cs
	namespace 	
DataAccessLayer
 
. 
DataBase "
{ 
public		 

	interface		 
IDataBaseSettings		 &
{

 
public 
string  
ClinicCollectionName *
{+ ,
get- 0
;0 1
set2 5
;5 6
}7 8
public 
string 
ConnectionString &
{' (
get) ,
;, -
set. 1
;1 2
}3 4
public 
string 
DatabaseName "
{# $
get% (
;( )
set* -
;- .
}/ 0
} 
} Ô
vC:\Users\921611\source\repos\Clinic Visit Appointment Booking System\UserMicroservice\DataAccessLayer\MappingConfig.cs
	namespace 	
DataAccessLayer
 
{ 
public 

class 
MappingConfig 
: 
Profile &
{ 
public		 
MappingConfig		 
(		 
)		 
{

 	
	CreateMap 
< 
Patient 
, 

PatientDto )
>) *
(* +
)+ ,
., -

ReverseMap- 7
(7 8
)8 9
;9 :
	CreateMap 
< 
Patient 
, 
PatientRegisterDto 1
>1 2
(2 3
)3 4
.4 5

ReverseMap5 ?
(? @
)@ A
;A B
	CreateMap 
< 

PatientDto  
,  !
PatientRegisterDto" 4
>4 5
(5 6
)6 7
.7 8

ReverseMap8 B
(B C
)C D
;D E
} 	
} 
} €
ÉC:\Users\921611\source\repos\Clinic Visit Appointment Booking System\UserMicroservice\DataAccessLayer\Models\DTO\LoginRequestDto.cs
	namespace 	
DataAccessLayer
 
. 
Models  
.  !
DTO! $
{ 
public		 

class		 
LoginRequestDto		  
{

 
public 
required 
string 
userName '
{( )
get* -
;- .
set/ 2
;2 3
}4 5
public 
required 
string 
password '
{( )
get* -
;- .
set/ 2
;2 3
}4 5
} 
} —
ÑC:\Users\921611\source\repos\Clinic Visit Appointment Booking System\UserMicroservice\DataAccessLayer\Models\DTO\LoginResponseDto.cs
	namespace 	
DataAccessLayer
 
. 
Models  
.  !
DTO! $
{		 
public

 

class

 
LoginResponseDto

 !
{ 
public 
string 
? 
id 
{ 
get 
;  
set! $
;$ %
}& '
[ 	
EmailAddress	 
] 
public 
string 
? 
email 
{ 
get "
;" #
set$ '
;' (
}) *
public 
string 
? 
token 
{ 
get "
;" #
set$ '
;' (
}) *
public 
string 
? 
userName 
{  !
get" %
;% &
set' *
;* +
}, -
} 
} ´
~C:\Users\921611\source\repos\Clinic Visit Appointment Booking System\UserMicroservice\DataAccessLayer\Models\DTO\PatientDto.cs
	namespace

 	
DataAccessLayer


 
.

 
Models

  
.

  !
DTO

! $
{ 
public 

class 

PatientDto 
{ 
public 
string 
? 
Id 
{ 
get  
;  !
set" %
;% &
}' (
public 
string 
? 
	FirstName !
{" #
get$ '
;' (
set) ,
;, -
}. /
public 
string 
? 
LastName  
{! "
get# &
;& '
set( +
;+ ,
}- .
public 
string 
? 
Email 
{ 
get  #
;# $
set% (
;( )
}* +
public 
string 
? 
UserName  
{! "
get# &
;& '
set( +
;+ ,
}- .
[ 	
DisplayFormat	 
( !
ApplyFormatInEditMode ,
=- .
true/ 3
,3 4
DataFormatString5 E
=F G
$strH X
)X Y
]Y Z
public 
DateTime 
? 
DateOfBirth %
{& '
get( +
;+ ,
set- 0
;0 1
}2 3
public 
string 
? 
Gender 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
string 
? 
PhoneNumber #
{$ %
get& )
;) *
set+ .
;. /
}0 1
} 
} å
ÜC:\Users\921611\source\repos\Clinic Visit Appointment Booking System\UserMicroservice\DataAccessLayer\Models\DTO\PatientRegisterDTO.cs
	namespace

 	
DataAccessLayer


 
.

 
Models

  
.

  !
DTO

! $
{ 
public 

class 
PatientRegisterDto #
{ 
public 
required 
string 
	FirstName (
{) *
get+ .
;. /
set0 3
;3 4
}5 6
public 
required 
string 
LastName '
{( )
get* -
;- .
set/ 2
;2 3
}4 5
[ 	
EmailAddress	 
] 
public 
required 
string 
Email $
{% &
get' *
;* +
set, /
;/ 0
}1 2
public 
required 
string 
UserName '
{( )
get* -
;- .
set/ 2
;2 3
}4 5
[ 	
Required	 
( 
ErrorMessage 
=  
$str! 7
)7 8
]8 9
[ 	
RegularExpression	 
( 
$str q
,q r
ErrorMessages 
=
Ä Å
$str
Ç ˙
)
˙ ˚
]
˚ ¸
[ 	
DataType	 
( 
DataType 
. 
Password #
)# $
]$ %
public 
required 
string 
Password '
{( )
get* -
;- .
set/ 2
;2 3
}4 5
[ 	
Required	 
( 
ErrorMessage 
=  
$str! @
)@ A
]A B
[ 	
DataType	 
( 
DataType 
. 
Password #
)# $
]$ %
[ 	
Compare	 
( 
$str 
, 
ErrorMessage )
=* +
$str, Y
)Y Z
]Z [
public 
required 
string 
Confirm_Password /
{0 1
get2 5
;5 6
set7 :
;: ;
}< =
[ 	
Required	 
( 
ErrorMessage 
=  
$str! :
): ;
]; <
[ 	
DataType	 
( 
DataType 
. 
Date 
)  
]  !
[ 	
DisplayFormat	 
( !
ApplyFormatInEditMode ,
=- .
true/ 3
,3 4
DataFormatString5 E
=F G
$strH X
)X Y
]Y Z
public   
DateTime   
DateOfBirth   $
{  % &
get  ' *
;  * +
set  , /
;  / 0
}  1 2
public!! 
required!! 
string!! 
Gender!! %
{!!& '
get!!( +
;!!+ ,
set!!- 0
;!!0 1
}!!2 3
public"" 
required"" 
string"" 
PhoneNumber"" *
{""+ ,
get""- 0
;""0 1
set""2 5
;""5 6
}""7 8
}## 
}$$ Ô'
wC:\Users\921611\source\repos\Clinic Visit Appointment Booking System\UserMicroservice\DataAccessLayer\Models\Patient.cs
	namespace 	
DataAccessLayer
 
. 
Models  
{ 
public 

class 
Patient 
{ 
[		 	
BsonId			 
]		 
[

 	
BsonRepresentation

	 
(

 
BsonType

 $
.

$ %
ObjectId

% -
)

- .
]

. /
public 
required 
string 
Id !
{" #
get$ '
;' (
set) ,
;, -
}. /
[ 	
Required	 
( 
ErrorMessage 
=  
$str! 8
)8 9
]9 :
[ 	
StringLength	 
( 
$num 
, 
MinimumLength &
=' (
$num( )
,) *
ErrorMessage* 6
=7 8
$str9 y
)y z
]z {
public 
required 
string 
	FirstName (
{) *
get+ .
;. /
set0 3
;3 4
}5 6
[ 	
Required	 
( 
ErrorMessage 
=  
$str! 7
)7 8
]8 9
[ 	
StringLength	 
( 
$num 
, 
MinimumLength '
=( )
$num* +
,+ ,
ErrorMessage- 9
=: ;
$str< {
){ |
]| }
public 
required 
string 
LastName '
{( )
get* -
;- .
set/ 2
;2 3
}4 5
[ 	
Required	 
( 
ErrorMessage 
=  
$str! 4
)4 5
]5 6
[ 	
EmailAddress	 
( 
ErrorMessage "
=# $
$str$ 6
)6 7
]7 8
public 
required 
string 
Email $
{% &
get' *
;* +
set, /
;/ 0
}1 2
[ 	
Required	 
( 
ErrorMessage 
=  
$str! 7
)7 8
]8 9
public 
required 
string 
UserName '
{( )
get* -
;- .
set/ 2
;2 3
}4 5
[ 	
Required	 
( 
ErrorMessage 
=  
$str! 7
)7 8
]8 9
[ 	
DataType	 
( 
DataType 
. 
Password #
)# $
]$ %
public 
required 
string 
Password '
{( )
get* -
;- .
set/ 2
;2 3
}4 5
[ 	
Required	 
( 
ErrorMessage 
=  
$str! @
)@ A
]A B
[ 	
DataType	 
( 
DataType 
. 
Password #
)# $
]$ %
[ 	
Compare	 
( 
$str 
, 
ErrorMessage )
=* +
$str, Y
)Y Z
]Z [
public   
required   
string   
Confirm_Password   /
{  0 1
get  2 5
;  5 6
set  7 :
;  : ;
}  < =
[!! 	
Required!!	 
(!! 
ErrorMessage!! 
=!!  
$str!!! :
)!!: ;
]!!; <
["" 	
DataType""	 
("" 
DataType"" 
."" 
Date"" 
)""  
]""  !
[## 	
DisplayFormat##	 
(## !
ApplyFormatInEditMode## ,
=##, -
true##- 1
,##1 2
DataFormatString##2 B
=##C D
$str##D T
)##T U
]##U V
public$$ 
required$$ 
DateTime$$  
DateOfBirth$$! ,
{$$- .
get$$/ 2
;$$2 3
set$$4 7
;$$7 8
}$$9 :
[%% 	
Required%%	 
(%% 
ErrorMessage%% 
=%%  
$str%%! 5
)%%5 6
]%%6 7
public&& 
required&& 
string&& 
Gender&& %
{&&& '
get&&( +
;&&+ ,
set&&- 0
;&&0 1
}&&2 3
['' 	
Required''	 
('' 
ErrorMessage'' 
=''  
$str''! ;
)''; <
]''< =
[(( 	
Phone((	 
](( 
public)) 
required)) 
string)) 
PhoneNumber)) *
{))+ ,
get))- 0
;))0 1
set))2 5
;))5 6
}))7 8
}++ 
},, À
wC:\Users\921611\source\repos\Clinic Visit Appointment Booking System\UserMicroservice\DataAccessLayer\PatientMapping.cs
	namespace		 	
DataAccessLayer		
 
{

 
public 

class 
PatientMapping 
{ 
public 
static 
void 
	Configure $
($ %
)% &
{ 	
BsonClassMap 
. 
RegisterClassMap )
<) *
Patient* 1
>1 2
(2 3
cm3 5
=>6 8
{ 
cm 
. 
AutoMap 
( 
) 
; 
cm 
. 
	MapMember 
( 
p 
=> !
p" #
.# $
DateOfBirth$ /
)/ 0
.0 1
SetSerializer1 >
(> ?
new? B 
CustomDateSerializerC W
(W X
)X Y
)Y Z
;Z [
} 
) 
; 
} 	
} 
} 