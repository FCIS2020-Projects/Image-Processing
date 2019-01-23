include irvine32.inc

.data
;no static data
.code
;-----------------------------------------------------
;Sum PROC Calculates 2 unsigned integers
;Recieves: 2 DWord parametes number 1 and number 2
;Return: the sum of the 2 unsigned numbers into the EAX
;------------------------------------------------------
Sum PROC int1:DWORD, int2:DWORD
	mov eax, int1
	add eax, int2
	ret
Sum ENDP

;-----------------------------------------------------
;SumArr PROC Calculates Sum of an array
;Recieves: Offset and the size of an array
;Return: the sum of the array into the EAX
;------------------------------------------------------
SumArr PROC arr:PTR DWORD, sz:DWORD
	push esi
	push ecx

	mov esi, arr
	mov ecx, sz
	mov eax, 0
	sum_loop:
		add eax, DWORD PTR [esi]
		add esi, 4
	loop sum_loop
	
	pop ecx
	pop esi
	Ret
SumArr ENDP

;----------------------------------------------------------------
;Sum PROC convert an array of bytes from lower case to upper case
;Recieves: offset of byte array and it's size
;---------------------------------------------------------------
ToUpper PROC str1:PTR BYTE, sz:DWORD
	push esi
	push ecx
	
	mov esi, str1
	mov ecx, sz
	l1:
		;input validations (Limitation the char to be between a and z)
		cmp byte ptr [esi], 'a'
		jb skip
		cmp byte ptr [esi], 'z'
		ja skip

		and byte ptr [esi], 11011111b
		skip:
		inc esi
	loop l1
	
	pop ecx
	pop esi
	ret
ToUpper ENDP


;#######################################################
;#					Project Procedures					#
;#######################################################



Invert proc redChannel:PTR DWORD, greenChannel:PTR DWORD, blueChannel:PTR DWORD, imageSize: DWORD
	PUSHAD


	MOV ECX, IMAGESIZE
	MOV ESI, REDCHANNEL
	L1:
		MOV EBX, 255
		MOV EAX, [ESI]
		SUB EBX, EAX
		MOV EAX, EBX
		CMP EAX, 0
		JL NEGATIVEVAL1
		
		JMP SKIP1

		NEGATIVEVAL1:
		MOV EAX, 0


		SKIP1:
		MOV [ESI], EAX
		ADD ESI, 4
		
	LOOP L1

		MOV ECX, IMAGESIZE
	MOV ESI, GREENCHANNEL

	L2:
		MOV EBX, 255
		MOV EAX, [ESI]
		SUB EBX, EAX
		MOV EAX, EBX
		CMP EAX, 0
		JL NEGATIVEVAL2
		
		JMP SKIP2

		NEGATIVEVAL2:
		MOV EAX, 0


		SKIP2:
		MOV [ESI], EAX
		ADD ESI, 4
		
	LOOP L2

		MOV ECX, IMAGESIZE
	MOV ESI, BLUECHANNEL

	L3:
		MOV EBX, 255
		MOV EAX, [ESI]
		SUB EBX, EAX
		MOV EAX, EBX
		CMP EAX, 0
		JL NEGATIVEVAL3
		
		JMP SKIP3

		NEGATIVEVAL3:
		MOV EAX, 0


		SKIP3:
		MOV [ESI], EAX
		ADD ESI, 4
		
	LOOP L3

	POPAD
	RET
Invert endp

;----------------------------------------------------------------
;ToGray PROC convert an image from RGB image with colors to an Gray image
;Recieves: offset of dword arrays and it's size ( red ,green and blue)
;return: offset of dword array with gray
;---------------------------------------------------------------

ToGray proc redarr:PTR DWORD , greenarr:PTR DWORD , bluearr:PTR DWORD , output:PTR DWORD , sz:DWORD
	pushad
	mov esi , redarr
	mov edi , greenarr
	mov edx , bluearr
	mov ebx , output
	mov ecx , sz
	LA:
		mov eax , [esi]
		add eax , [edi]
		add eax , [edx]
		push ebx
		mov bl, 3
		div bl
		pop ebx
		mov [ebx] , al
		add ebx , 4
		add esi , 4
		add edi , 4
		add edx , 4
	loop LA
	popad
	ret
ToGray endp

;----------------------------------------------------------------
;PadwithZero PROC convert an image from original RGB image to an 2d image with zeros on the edges
;Recieves: offset of dword array and it's size 
;return: offset of dword array with zeros edges
;---------------------------------------------------------------

PadWithZero PROC arr : PTR DWORD, arr1 : PTR DWORD, sizecol : DWORD, sizerow : DWORD
	PUSHAD
; ------------------------ - make the first row zeros in big array(arr1)------------------------------

	mov edi, arr1
	mov eax, sizecol
	add eax, 2
	mov ecx, eax
	LOOP1 :
		mov dword ptr[edi], 0
		add edi, 4
	loop LOOP1
; ------------ - make  first element and last element zeros in each row in big array(arr1) and copy val from arr to arr1----------

	mov esi, arr
	mov ecx, sizerow
	LOOP2 :
		mov ebx, ecx
		mov dword ptr[edi], 0
		add edi, 4

		mov ecx, sizecol
		LOOP9 :
			mov eax, [esi]
			mov[edi], eax
			add edi, 4
			add esi, 4
		loop LOOP9
		mov dword ptr[edi], 0
		add edi, 4

		mov ecx, ebx
	loop LOOP2
; ------------------------------ - make the last row zeros in big array(arr1)--------------------

	mov eax, sizecol
	add eax, 2
	mov ecx, eax
	LOOP3 :
		mov dword ptr[edi], 0
		add edi, 4
	loop LOOP3

	POPAD
	RET
PadWithZero ENDP

;----------------------------------------------------------------
;Conv PROC convert an image from original RGB image to an 2d image that been mul with a 3*3 kernal aray
;Recieves: offset of dword array and it's size 
;return: offset of dword array with mul with a 3*3 kernal array
;---------------------------------------------------------------

Conv PROC iimgarr:PTR DWORD, oimgarr:PTR DWORD, kernel:PTR SDWORD, cols:DWORD, rows : DWORD
	PUSHAD

	MOV ESI, iimgarr
	MOV EDI, oimgarr
	MOV ECX, rows
	LOOP1 :
		PUSH ECX
		MOV ECX, cols
		LOOP2 :
			PUSH ECX
			PUSH ESI
			MOV EBX, kernel
			MOV ECX, 3
			LOOP3 :
				PUSH ECX
				MOV ECX, 3
				LOOP4 :
					MOV EAX, 0
					MOV AX, [ESI]
					IMUL WORD PTR[EBX]
					MOVSX EAX, AX
					ADD [EDI], EAX
					ADD ESI, 4
					ADD EBX, 4
				LOOP LOOP4

				MOV EAX, cols
				ADD EAX, 2
				SUB EAX, 3
				SHL EAX, 2
				ADD ESI, EAX

				POP ECX
			LOOP LOOP3
			POP ESI
			ADD ESI, 4
			ADD EDI, 4
			POP ECX
		LOOP LOOP2
		MOV EAX, 2
		SHL EAX, 2
		ADD ESI, EAX
		POP ECX
	LOOP LOOP1
	
	POPAD
	RET
Conv ENDP

;----------------------------------------------------------------
;div PROC convert an image from original RGB image to an 2d image that been Divided by 16
;Recieves: offset of dword array and it's size 
;return: offset of dword array with 16
;---------------------------------------------------------------

DDiv PROC image:PTR DWORD, S:DWORD
	PUSHAD

	MOV ecx, S
	MOV edi, image
	L1:
		MOV eax,[edi]
		MOV edx, 0
		MOV ebx, 16
		DIV ebx
		MOV [edi],eax
		add edi,4
	LOOP L1
	POPAD
	RET
DDiv ENDP

;----------------------------------------------------------------
;Scale PROC convert an image from an over 255 numbers to scale them to be between 0 - 255
;Recieves: offset of dword array and it's size 
;return: offset of dword array with scaled numbers between 0 - 255
;---------------------------------------------------------------

Scale PROC image:PTR DWORD, S:DWORD
	PUSHAD

	MOV ecx, S
	MOV edx, image
	MOV eax, [edx]
	MOV esi, eax
	MOV edi, eax
	L1 :
		ADD edx, 4
		MOV eax, [edx]
		CMP eax, esi
		JNL Next1
			MOV esi, eax
		Next1 :
		CMP eax, edi
		JNG Next2
			MOV edi, eax
		Next2 :
	LOOP L1
	MOV ecx, S
	MOV edx, image
	L2 :
		PUSH edx
		MOV eax, [edx]
		SUB eax, esi
		MOV ebx, 255
		MUL ebx
		MOV ebx, edi
		SUB ebx, esi
		DIV ebx

		POP edx
		MOV[edx], eax
		ADD edx, 4

	LOOP L2
	POPAD
	RET
Scale ENDP

;----------------------------------------------------------------
;FreqArr PROC convert an image from original RGB image to a 1d array with freq of every pixels
;Recieves: offset of dword array and it's size 
;return: offset of dword array with a 1d array with freq of every pixels
;---------------------------------------------------------------

FreqArr PROC arr:ptr dword, accarr:ptr dword, sz:dword
	PUSHAD

;-------------------------Fill the accumulation array------------------------------  	
	mov ecx,sz               
	mov esi,arr
	mov edi,accarr ;  now we know the number of elements we will loop on them using (esi) register and indirect offset 

    LOOP2:                ; we will take the value from the array use it as an index in the accumulation array and increse by one while spanning the whole array   
	
	mov eax,[esi]
	mov edi,accarr
	add edi,eax
	add edi,eax
	add edi,eax
	add edi,eax
	add dword ptr[edi],1
	add esi,4
	
	loop LOOP2

	POPAD
    RET
FreqArr ENDP

;----------------------------------------------------------------
;CumSum PROC convert an freq array to an array with comulative sum of image color
;Recieves: offset of dword array
;return: offset of dword array with comulative sum of image color
;---------------------------------------------------------------

CumSum PROC arr:PTR DWORD
	PUSHAD
		mov esi, arr
		mov ecx, 256
		mov eax, 0
		sum_loop:
			add eax, DWORD PTR [esi]		
			mov [esi], eax
	
			add esi, 4
		loop sum_loop
	POPAD
	RET
CumSum ENDP

;----------------------------------------------------------------
;Equalize PROC take an comulative sum array of colors and put them inside an coresponding function that was given
;Recieves: offset of dword array and it's size 
;return: offset of dword array 
;---------------------------------------------------------------


Equalize PROC ARR:PTR DWORD, IMAGESIZE:DWORD
	PUSHAD

	MOV ESI, ARR
	MOV EAX, 0
	MOV [ESI], EAX
	ADD ESI, 4
	MOV ECX, 255
	LOOP1:
		MOV EAX, [ESI]
		ADD EAX, [ESI - 4]
		MOV EBX, 255
		MUL EBX
		MOV EDX, 0
		DIV IMAGESIZE
		MOV[ESI], EAX
		ADD ESI, 4
	LOOP LOOP1

	POPAD
	RET
Equalize ENDP

;diffrent way also works

Equalize2 PROC ARR : PTR DWORD, IMAGESIZE : DWORD
	PUSHAD
	MOV ESI, ARR
	MOV ECX, 256
	GETMIN:
		MOV EAX, [ESI]
		CMP EAX, 0
		JNE CONTINUE
		ADD ESI, 4
	LOOP GETMIN
	CONTINUE :
	MOV EDI, [ESI]
	MOV ESI, ARR
	MOV ECX, 256
	CALC :
		MOV EAX, [ESI]
		SUB EAX, EDI
		MOV EBX, 255
		MUL EBX
		MOV EDX, 0
		MOV EBX, IMAGESIZE
		SUB EBX, EDI
		DIV EBX
		MOV [ESI], EAX
		ADD ESI, 4
	LOOP CALC

	POPAD
	RET
Equalize2 ENDP

;----------------------------------------------------------------
;NewImage PROC take an array and convert them to a functional image
;Recieves: offset of dword array and it's size 
;return: offset of dword array 
;---------------------------------------------------------------

NewImage PROC image:ptr DWORD,Farr:ptr DWORD,ImageS: DWORD
    PUSHAD
	mov ecx,ImageS
	mov edx, image
	mov ebx, Farr
	L1:
		MOV eax,[edx]
		SHL eax,2
		MOV eax,[ebx+eax]
		MOV [edx],eax
		mov eax,[edx]
		ADD edx,4
	LOOP L1
	POPAD
    RET
NewImage ENDP

;----------------------------------------------------------------
;AddImages PROC take two images and return thier addition 
;Recieves: offset of 2 dword array and it's size 
;return: offset of dword array 
;---------------------------------------------------------------

AddImages PROC INPIMG1: PTR DWORD, INPIMG2: PTR DWORD, OUTIMG: PTR DWORD, ImageSize: DWORD
	PUSHAD

	MOV ESI, INPIMG1
	MOV EDI, INPIMG2
	MOV EDX, OUTIMG

	MOV ECX, ImageSize
	L1:
		MOV EAX, [ESI]
		ADD EAX, [EDI]
		MOV [EDX], EAX
		ADD ESI, 4
		ADD EDI, 4
		ADD EDX, 4
	LOOP L1

	POPAD
	RET
AddImages ENDP

;----------------------------------------------------------------
;SubImages PROC take two images and return thier Substraction 
;Recieves: offset of 2 dword array and it's size 
;return: offset of dword array 
;---------------------------------------------------------------

SubImages PROC INPIMG1 : PTR DWORD, INPIMG2 : PTR DWORD, OUTIMG : PTR DWORD, ImageSize : DWORD
	PUSHAD

	MOV ESI, INPIMG1
	MOV EDI, INPIMG2
	MOV EDX, OUTIMG

	MOV ECX, ImageSize
	L1 :
		MOV EAX, [ESI]
		SUB EAX, [EDI]
		MOV [EDX], EAX
		ADD ESI, 4
		ADD EDI, 4
		ADD EDX, 4
	LOOP L1

	POPAD
	RET
SubImages ENDP

; DllMain is required for any DLL
DllMain PROC hInstance:DWORD, fdwReason:DWORD, lpReserved:DWORD
mov eax, 1 ; Return true to caller.
ret
DllMain ENDP
END DllMain