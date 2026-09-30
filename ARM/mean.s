@ Constants
.equ STACK_SIZE, 4096
@ Global Symbols
.global main

@ Uninitialized Data Segment
.bss
.skip STACK_SIZE
stack: .skip 4

@ Code Segment
.text
@ Signature: int mean(int a, int b, int c, int d, int e, int f)
@ Input: r0, r1, r2, r3, [sp], [sp+4]
@ Output: r0
mean:
    @ Frame Creation
    push {fp, lr}
    mov fp, sp
    push {r1, r3}

    @ Calculate mean
    add r0, r0, r1 @ b
    add r0, r0, r2 @ c
    add r0, r0, r3 @ d
    ldr r1, [fp, #8]
    add r0, r0, r1 @ e
    ldr r1, [fp, #12]
    add r0, r0, r1 @ f
    mov r1, #6
    sdiv r0, r0, r1

    @ Restore Frame
    pop {r1, r3}
    pop {fp, lr}

    @ Return
    mov pc, lr

@ Signature: int main()
@ Output: r0
main:
    @ Stack initialization
    ldr sp, =stack

    @ Frame Creation
    push {fp, lr}
    mov fp, sp
    push {r1, r3}
    sub sp, sp, #4 @ Local variable mean

    @ Prepare arguments for mean
    sub sp, sp, #8
    mov r3, #6
    str r3, [sp, #4]
    mov r3, #5
    str r3, [sp]
    mov r3, #4
    mov r2, #3
    mov r1, #2
    mov r0, #1
    bl mean
    add sp, sp, #8

    @ Save result
    str r0, [sp]

    @ Restore Frame
    add sp, sp, #4
    pop {r1, r3}
    pop {fp, lr}

    @ Return from main
    mov r0, #0
    mov pc, lr