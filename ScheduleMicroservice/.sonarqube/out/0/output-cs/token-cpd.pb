∑

ÜC:\Users\921611\source\repos\Clinic Visit Appointment Booking System\ScheduleMicroservice\DataAccessLayer\DataBase\DataBaseSettings.cs
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
string !
ClinicCollectionName1 4
{5 6
get7 :
;: ;
set< ?
;? @
}A B
public 
required 
string !
ClinicCollectionName2 4
{5 6
get7 :
;: ;
set< ?
;? @
}A B
public 
required 
string 
ConnectionString /
{0 1
get2 5
;5 6
set7 :
;: ;
}< =
public 
required 
string 
DatabaseName +
{, -
get. 1
;1 2
set3 6
;6 7
}8 9
} 
} °	
áC:\Users\921611\source\repos\Clinic Visit Appointment Booking System\ScheduleMicroservice\DataAccessLayer\DataBase\IDataBaseSettings.cs
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
string !
ClinicCollectionName1 +
{, -
get. 1
;1 2
set3 6
;6 7
}8 9
public 
string !
ClinicCollectionName2 +
{, -
get. 1
;1 2
set3 6
;6 7
}8 9
public 
string 
ConnectionString &
{' (
get) ,
;, -
set. 1
;1 2
}3 4
public 
string 
DatabaseName "
{# $
get% (
;( )
set* -
;- .
}/ 0
} 
} ô
zC:\Users\921611\source\repos\Clinic Visit Appointment Booking System\ScheduleMicroservice\DataAccessLayer\MappingConfig.cs
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
< 
ClinicServices $
,$ %
ClinicServicesDto& 7
>7 8
(8 9
)9 :
.: ;

ReverseMap; E
(E F
)F G
;G H
	CreateMap 
< 
ClinicServices $
,$ %#
ClinicServicesCreateDto& =
>= >
(> ?
)? @
.@ A

ReverseMapA K
(K L
)L M
;M N
	CreateMap 
< 
ClinicServicesDto '
,' (#
ClinicServicesCreateDto) @
>@ A
(A B
)B C
.C D

ReverseMapD N
(N O
)O P
;P Q
	CreateMap 
< 
ScheduleAppointment )
,) *"
ScheduleAppointmentDto+ A
>A B
(B C
)C D
.D E

ReverseMapE O
(O P
)P Q
;Q R
	CreateMap 
< 
ScheduleAppointment )
,) *(
ScheduleAppointmentCreateDto+ G
>G H
(H I
)I J
.J K

ReverseMapK U
(U V
)V W
;W X
	CreateMap 
< "
ScheduleAppointmentDto ,
,, -(
ScheduleAppointmentCreateDto. J
>J K
(K L
)L M
.M N

ReverseMapN X
(X Y
)Y Z
;Z [
} 	
} 
} æ
ÇC:\Users\921611\source\repos\Clinic Visit Appointment Booking System\ScheduleMicroservice\DataAccessLayer\Models\ClinicServices.cs
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
{ 
public 

class 
ClinicServices 
{ 
[ 	
BsonId	 
] 
[ 	
BsonRepresentation	 
( 
BsonType $
.$ %
ObjectId% -
)- .
]. /
public 
required 
string 
Id !
{" #
get$ '
;' (
set) ,
;, -
}. /
[ 	
Required	 
( 
ErrorMessage 
=  
$str! 9
)9 :
]: ;
public 
required 
string 

ClinicName )
{* +
get, /
;/ 0
set1 4
;4 5
}6 7
[ 	
Required	 
( 
ErrorMessage 
=  
$str! <
)< =
]= >
public 
required 
string 
ClinicAddress ,
{- .
get/ 2
;2 3
set4 7
;7 8
}9 :
[ 	
Required	 
( 
ErrorMessage 
=  
$str! 7
)7 8
]8 9
public 
required 
List 
< 
string #
># $
Services% -
{. /
get0 3
;3 4
set5 8
;8 9
}: ;
} 
} ÿ
èC:\Users\921611\source\repos\Clinic Visit Appointment Booking System\ScheduleMicroservice\DataAccessLayer\Models\DTO\ClinicServicesCreateDto.cs
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
 #
ClinicServicesCreateDto

 (
{ 
public 
required 
string 

ClinicName )
{* +
get, /
;/ 0
set1 4
;4 5
}6 7
public 
required 
string 
ClinicAddress ,
{- .
get/ 2
;2 3
set4 7
;7 8
}9 :
public 
required 
List 
< 
string #
># $
Services% -
{. /
get0 3
;3 4
set5 8
;8 9
}: ;
} 
} ‹
âC:\Users\921611\source\repos\Clinic Visit Appointment Booking System\ScheduleMicroservice\DataAccessLayer\Models\DTO\ClinicServicesDto.cs
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
class		 
ClinicServicesDto		 "
{

 
public 
string 
? 
Id 
{ 
get 
;  
set! $
;$ %
}& '
public 
string 
? 

ClinicName !
{" #
get$ '
;' (
set) ,
;, -
}. /
public 
string 
? 
ClinicAddress $
{% &
get' *
;* +
set, /
;/ 0
}1 2
public 
List 
< 
string 
> 
? 
Services %
{& '
get( +
;+ ,
set- 0
;0 1
}2 3
} 
} è

îC:\Users\921611\source\repos\Clinic Visit Appointment Booking System\ScheduleMicroservice\DataAccessLayer\Models\DTO\ScheduleAppointmentCreateDto.cs
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
 (
ScheduleAppointmentCreateDto

 -
{ 
public 
required 
string 
PatientuserName .
{/ 0
get1 4
;4 5
set6 9
;9 :
}; <
public 
required 
string 

ClinicName )
{* +
get, /
;/ 0
set1 4
;4 5
}6 7
public 
required 
string 
ClinicAddress ,
{- .
get/ 2
;2 3
set4 7
;7 8
}9 :
public 
required 
string 
Service &
{' (
get) ,
;, -
set. 1
;1 2
}3 4
public 
DateTime 
DateTimeOfVisit '
{( )
get* -
;- .
set/ 2
;2 3
}4 5
} 
} å
éC:\Users\921611\source\repos\Clinic Visit Appointment Booking System\ScheduleMicroservice\DataAccessLayer\Models\DTO\ScheduleAppointmentDto.cs
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
 "
ScheduleAppointmentDto

 '
{ 
public 
string 
? 
Id 
{ 
get 
;  
set! $
;$ %
}& '
public 
string 
? 
PatientuserName &
{' (
get) ,
;, -
set. 1
;1 2
}3 4
public 
string 
? 

ClinicName !
{" #
get$ '
;' (
set) ,
;, -
}. /
public 
string 
? 
ClinicAddress $
{% &
get' *
;* +
set, /
;/ 0
}1 2
public 
string 
? 
Service 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
DateTime 
DateTimeOfVisit '
{( )
get* -
;- .
set/ 2
;2 3
}4 5
} 
} è
áC:\Users\921611\source\repos\Clinic Visit Appointment Booking System\ScheduleMicroservice\DataAccessLayer\Models\ScheduleAppointment.cs
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
{ 
public 

class 
ScheduleAppointment $
{ 
[ 	
BsonId	 
] 
[ 	
BsonRepresentation	 
( 
BsonType $
.$ %
ObjectId% -
)- .
]. /
public 
required 
string 
Id !
{" #
get$ '
;' (
set) ,
;, -
}. /
[ 	
Required	 
( 
ErrorMessage 
= 
$str  9
)9 :
]: ;
public 
required 
string 
PatientuserName .
{/ 0
get1 4
;4 5
set6 9
;9 :
}; <
[ 	
Required	 
( 
ErrorMessage 
=  
$str! 9
)9 :
]: ;
public 
required 
string 

ClinicName )
{* +
get, /
;/ 0
set1 4
;4 5
}6 7
[ 	
Required	 
( 
ErrorMessage 
=  
$str! <
)< =
]= >
public 
required 
string 
ClinicAddress ,
{- .
get/ 2
;2 3
set4 7
;7 8
}9 :
[ 	
Required	 
( 
ErrorMessage 
=  
$str! 6
)6 7
]7 8
public 
required 
string 
Service &
{' (
get) ,
;, -
set. 1
;1 2
}3 4
[ 	
Required	 
( 
ErrorMessage 
=  
$str! >
)> ?
]? @
public 
DateTime 
DateTimeOfVisit '
{( )
get* -
;- .
set/ 2
;2 3
}4 5
} 
} 