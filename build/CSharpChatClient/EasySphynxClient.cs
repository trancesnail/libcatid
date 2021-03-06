/* ----------------------------------------------------------------------------
 * This file was automatically generated by SWIG (http://www.swig.org).
 * Version 2.0.2
 *
 * Do not make changes to this file unless you know what you are doing--modify
 * the SWIG interface file instead.
 * ----------------------------------------------------------------------------- */


using System;
using System.Runtime.InteropServices;

public class EasySphynxClient : IDisposable {
  private HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal EasySphynxClient(IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new HandleRef(this, cPtr);
  }

  internal static HandleRef getCPtr(EasySphynxClient obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }

  ~EasySphynxClient() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          SphynxPINVOKE.delete_EasySphynxClient(swigCPtr);
        }
        swigCPtr = new HandleRef(null, IntPtr.Zero);
      }
      GC.SuppressFinalize(this);
    }
  }

  public EasySphynxClient() : this(SphynxPINVOKE.new_EasySphynxClient(), true) {
    SwigDirectorConnect();
  }

  public unsafe bool Connect(string hostname, ushort port, byte[] public_key, int public_key_bytes, string session_key) {
    fixed ( byte* swig_ptrTo_public_key = public_key ) {
    {
      bool ret = SphynxPINVOKE.EasySphynxClient_Connect(swigCPtr, hostname, port, (IntPtr)swig_ptrTo_public_key, public_key_bytes, session_key);
      return ret;
    }
    }
  }

  public unsafe bool WriteOOB(byte msg_opcode, byte[] msg_data, uint msg_bytes) {
    fixed ( byte* swig_ptrTo_msg_data = msg_data ) {
    {
      bool ret = SphynxPINVOKE.EasySphynxClient_WriteOOB(swigCPtr, msg_opcode, (IntPtr)swig_ptrTo_msg_data, msg_bytes);
      return ret;
    }
    }
  }

  public unsafe bool WriteUnreliable(byte msg_opcode, byte[] msg_data, uint msg_bytes) {
    fixed ( byte* swig_ptrTo_msg_data = msg_data ) {
    {
      bool ret = SphynxPINVOKE.EasySphynxClient_WriteUnreliable(swigCPtr, msg_opcode, (IntPtr)swig_ptrTo_msg_data, msg_bytes);
      return ret;
    }
    }
  }

  public unsafe bool WriteReliable(uint stream, byte msg_opcode, byte[] msg_data, uint msg_bytes) {
    fixed ( byte* swig_ptrTo_msg_data = msg_data ) {
    {
      bool ret = SphynxPINVOKE.EasySphynxClient_WriteReliable(swigCPtr, stream, msg_opcode, (IntPtr)swig_ptrTo_msg_data, msg_bytes);
      return ret;
    }
    }
  }

  public void FlushAfter() {
    SphynxPINVOKE.EasySphynxClient_FlushAfter(swigCPtr);
  }

  public void FlushWrites() {
    SphynxPINVOKE.EasySphynxClient_FlushWrites(swigCPtr);
  }

  public uint getLocalTime() {
    uint ret = SphynxPINVOKE.EasySphynxClient_getLocalTime(swigCPtr);
    return ret;
  }

  public uint toServerTime(uint local_time) {
    uint ret = SphynxPINVOKE.EasySphynxClient_toServerTime(swigCPtr, local_time);
    return ret;
  }

  public uint fromServerTime(uint server_time) {
    uint ret = SphynxPINVOKE.EasySphynxClient_fromServerTime(swigCPtr, server_time);
    return ret;
  }

  public uint getServerTime() {
    uint ret = SphynxPINVOKE.EasySphynxClient_getServerTime(swigCPtr);
    return ret;
  }

  public ushort encodeClientTimestamp(uint local_time) {
    ushort ret = SphynxPINVOKE.EasySphynxClient_encodeClientTimestamp(swigCPtr, local_time);
    return ret;
  }

  public uint decodeServerTimestamp(uint local_time, ushort timestamp) {
    uint ret = SphynxPINVOKE.EasySphynxClient_decodeServerTimestamp(swigCPtr, local_time, timestamp);
    return ret;
  }

  public virtual void OnDisconnect(string reason) {
    if (SwigDerivedClassHasMethod("OnDisconnect", swigMethodTypes0)) SphynxPINVOKE.EasySphynxClient_OnDisconnectSwigExplicitEasySphynxClient(swigCPtr, reason); else SphynxPINVOKE.EasySphynxClient_OnDisconnect(swigCPtr, reason);
  }

  public virtual void OnConnectFailure(string reason) {
    if (SwigDerivedClassHasMethod("OnConnectFailure", swigMethodTypes1)) SphynxPINVOKE.EasySphynxClient_OnConnectFailureSwigExplicitEasySphynxClient(swigCPtr, reason); else SphynxPINVOKE.EasySphynxClient_OnConnectFailure(swigCPtr, reason);
  }

  public virtual void OnConnectSuccess() {
    if (SwigDerivedClassHasMethod("OnConnectSuccess", swigMethodTypes2)) SphynxPINVOKE.EasySphynxClient_OnConnectSuccessSwigExplicitEasySphynxClient(swigCPtr); else SphynxPINVOKE.EasySphynxClient_OnConnectSuccess(swigCPtr);
  }

  public virtual void OnMessageArrivals(IntPtr msgs, int count) {
    if (SwigDerivedClassHasMethod("OnMessageArrivals", swigMethodTypes3)) SphynxPINVOKE.EasySphynxClient_OnMessageArrivalsSwigExplicitEasySphynxClient(swigCPtr, msgs, count); else SphynxPINVOKE.EasySphynxClient_OnMessageArrivals(swigCPtr, msgs, count);
  }

  private void SwigDirectorConnect() {
    if (SwigDerivedClassHasMethod("OnDisconnect", swigMethodTypes0))
      swigDelegate0 = new SwigDelegateEasySphynxClient_0(SwigDirectorOnDisconnect);
    if (SwigDerivedClassHasMethod("OnConnectFailure", swigMethodTypes1))
      swigDelegate1 = new SwigDelegateEasySphynxClient_1(SwigDirectorOnConnectFailure);
    if (SwigDerivedClassHasMethod("OnConnectSuccess", swigMethodTypes2))
      swigDelegate2 = new SwigDelegateEasySphynxClient_2(SwigDirectorOnConnectSuccess);
    if (SwigDerivedClassHasMethod("OnMessageArrivals", swigMethodTypes3))
      swigDelegate3 = new SwigDelegateEasySphynxClient_3(SwigDirectorOnMessageArrivals);
    SphynxPINVOKE.EasySphynxClient_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3);
  }

  private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes) {
    System.Reflection.MethodInfo methodInfo = this.GetType().GetMethod(methodName, System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance, null, methodTypes, null);
    bool hasDerivedMethod = methodInfo.DeclaringType.IsSubclassOf(typeof(EasySphynxClient));
    return hasDerivedMethod;
  }

  private void SwigDirectorOnDisconnect(string reason) {
    OnDisconnect(reason);
  }

  private void SwigDirectorOnConnectFailure(string reason) {
    OnConnectFailure(reason);
  }

  private void SwigDirectorOnConnectSuccess() {
    OnConnectSuccess();
  }

  private void SwigDirectorOnMessageArrivals(IntPtr msgs, int count) {
    OnMessageArrivals(msgs, count);
  }

  public delegate void SwigDelegateEasySphynxClient_0(string reason);
  public delegate void SwigDelegateEasySphynxClient_1(string reason);
  public delegate void SwigDelegateEasySphynxClient_2();
  public delegate void SwigDelegateEasySphynxClient_3(IntPtr msgs, int count);

  private SwigDelegateEasySphynxClient_0 swigDelegate0;
  private SwigDelegateEasySphynxClient_1 swigDelegate1;
  private SwigDelegateEasySphynxClient_2 swigDelegate2;
  private SwigDelegateEasySphynxClient_3 swigDelegate3;

  private static Type[] swigMethodTypes0 = new Type[] { typeof(string) };
  private static Type[] swigMethodTypes1 = new Type[] { typeof(string) };
  private static Type[] swigMethodTypes2 = new Type[] {  };
  private static Type[] swigMethodTypes3 = new Type[] { typeof(IntPtr), typeof(int) };
}
