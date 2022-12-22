#include "pch-cpp.hpp"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif


#include <limits>
#include <stdint.h>


template <typename T1>
struct VirtualActionInvoker1
{
	typedef void (*Action)(void*, T1, const RuntimeMethod*);

	static inline void Invoke (Il2CppMethodSlot slot, RuntimeObject* obj, T1 p1)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_virtual_invoke_data(slot, obj);
		((Action)invokeData.methodPtr)(obj, p1, invokeData.method);
	}
};
template <typename T1>
struct GenericVirtualActionInvoker1
{
	typedef void (*Action)(void*, T1, const RuntimeMethod*);

	static inline void Invoke (const RuntimeMethod* method, RuntimeObject* obj, T1 p1)
	{
		VirtualInvokeData invokeData;
		il2cpp_codegen_get_generic_virtual_invoke_data(method, obj, &invokeData);
		((Action)invokeData.methodPtr)(obj, p1, invokeData.method);
	}
};
template <typename T1>
struct InterfaceActionInvoker1
{
	typedef void (*Action)(void*, T1, const RuntimeMethod*);

	static inline void Invoke (Il2CppMethodSlot slot, RuntimeClass* declaringInterface, RuntimeObject* obj, T1 p1)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_interface_invoke_data(slot, obj, declaringInterface);
		((Action)invokeData.methodPtr)(obj, p1, invokeData.method);
	}
};
template <typename T1>
struct GenericInterfaceActionInvoker1
{
	typedef void (*Action)(void*, T1, const RuntimeMethod*);

	static inline void Invoke (const RuntimeMethod* method, RuntimeObject* obj, T1 p1)
	{
		VirtualInvokeData invokeData;
		il2cpp_codegen_get_generic_interface_invoke_data(method, obj, &invokeData);
		((Action)invokeData.methodPtr)(obj, p1, invokeData.method);
	}
};
template <typename T1>
struct InvokerActionInvoker1
{
	static inline void Invoke (Il2CppMethodPointer methodPtr, const RuntimeMethod* method, void* obj, T1 p1)
	{
		void* params[1] = { &p1 };
		method->invoker_method(methodPtr, method, obj, params, NULL);
	}
};
template <typename T1>
struct InvokerActionInvoker1<T1*>
{
	static inline void Invoke (Il2CppMethodPointer methodPtr, const RuntimeMethod* method, void* obj, T1* p1)
	{
		void* params[1] = { p1 };
		method->invoker_method(methodPtr, method, obj, params, NULL);
	}
};
template <typename T1, typename T2>
struct InvokerActionInvoker2;
template <typename T1, typename T2>
struct InvokerActionInvoker2<T1*, T2>
{
	static inline void Invoke (Il2CppMethodPointer methodPtr, const RuntimeMethod* method, void* obj, T1* p1, T2 p2)
	{
		void* params[2] = { p1, &p2 };
		method->invoker_method(methodPtr, method, obj, params, NULL);
	}
};
template <typename T1, typename T2>
struct InvokerActionInvoker2<T1*, T2*>
{
	static inline void Invoke (Il2CppMethodPointer methodPtr, const RuntimeMethod* method, void* obj, T1* p1, T2* p2)
	{
		void* params[2] = { p1, p2 };
		method->invoker_method(methodPtr, method, obj, params, NULL);
	}
};
template <typename T1, typename T2, typename T3>
struct InvokerActionInvoker3;
template <typename T1, typename T2, typename T3>
struct InvokerActionInvoker3<T1*, T2*, T3>
{
	static inline void Invoke (Il2CppMethodPointer methodPtr, const RuntimeMethod* method, void* obj, T1* p1, T2* p2, T3 p3)
	{
		void* params[3] = { p1, p2, &p3 };
		method->invoker_method(methodPtr, method, obj, params, NULL);
	}
};

// System.Delegate[]
struct DelegateU5BU5D_tC5AB7E8F745616680F337909D3A8E6C722CDF771;
// System.IntPtr[]
struct IntPtrU5BU5D_tFD177F8C806A6921AD7150264CCC62FA00CAD832;
// UnityEngine.Playables.PlayableBinding[]
struct PlayableBindingU5BU5D_tC50C3F27A8E4246488F7A5998CAABAC4811A92CD;
// System.Single[]
struct SingleU5BU5D_t89DEFE97BCEDB5857010E79ECE0F52CF6E93B87C;
// System.Diagnostics.StackTrace[]
struct StackTraceU5BU5D_t32FBCB20930EAF5BAE3F450FF75228E5450DA0DF;
// System.Type[]
struct TypeU5BU5D_t97234E1129B564EB38B8D85CAC2AD8B5B9522FFB;
// System.Action
struct Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07;
// System.ArgumentException
struct ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263;
// UnityEngine.AudioClip
struct AudioClip_t5D272C4EB4F2D3ED49F1C346DEA373CF6D585F20;
// UnityEngine.Experimental.Audio.AudioSampleProvider
struct AudioSampleProvider_t602353124A2F6F2AEC38E56C3C21932344F712E2;
// UnityEngine.AudioSource
struct AudioSource_t871AC2272F896738252F04EE949AEF5B241D3299;
// System.Reflection.Binder
struct Binder_t91BFCE95A7057FADF4D8A1A342AFE52872246235;
// System.Delegate
struct Delegate_t;
// System.DelegateData
struct DelegateData_t9B286B493293CD2D23A5B2B5EF0E5B1324C2B77E;
// System.Collections.IDictionary
struct IDictionary_t6D03155AF1FA9083817AA5B6AD7DEEACC26AB220;
// System.InvalidCastException
struct InvalidCastException_t47FC62F21A3937E814D20381DDACEF240E95AC2E;
// System.Reflection.MemberFilter
struct MemberFilter_tF644F1AE82F611B677CE1964D5A3277DDA21D553;
// System.Reflection.MethodInfo
struct MethodInfo_t;
// UnityEngine.Object
struct Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C;
// System.Runtime.Serialization.SafeSerializationManager
struct SafeSerializationManager_tCBB85B95DFD1634237140CD892E82D06ECB3F5E6;
// System.String
struct String_t;
// System.Type
struct Type_t;
// System.Void
struct Void_t4861ACF8F4594C3437BB48B6E56783494B843915;
// UnityEngine.AudioClip/PCMReaderCallback
struct PCMReaderCallback_t3396D9613664F0AFF65FB91018FD0F901CC16F1E;
// UnityEngine.AudioClip/PCMSetPositionCallback
struct PCMSetPositionCallback_t8D7135A2FB40647CAEC93F5254AD59E18DEB6072;
// UnityEngine.Experimental.Audio.AudioSampleProvider/SampleFramesHandler
struct SampleFramesHandler_tFE84FF9BBCEFB880D46227188F375BEF680AAA30;
// UnityEngine.AudioSettings/AudioConfigurationChangeHandler
struct AudioConfigurationChangeHandler_tE071B0CBA3B3A77D3E41F5FCB65B4017885B3177;
// UnityEngine.Playables.PlayableBinding/CreateOutputMethod
struct CreateOutputMethod_tD18AFE3B69E6DDD913D82D5FA1D5D909CEEC8509;

IL2CPP_EXTERN_C Il2CppSequencePoint g_sequencePointsUnityEngine_AudioModule[];
IL2CPP_EXTERN_C RuntimeClass* ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* AudioSettings_t66C4BCA1E463B061E2EC9063FB882ACED20D47BD_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* CreateOutputMethod_tD18AFE3B69E6DDD913D82D5FA1D5D909CEEC8509_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* InvalidCastException_t47FC62F21A3937E814D20381DDACEF240E95AC2E_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* PlayableBinding_tB68B3BAC47F4F4C559640472174D5BEF93CB6AB4_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* PlayableOutputHandle_tEB217645A8C0356A3AC6F964F283003B9740E883_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Type_t_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C String_t* _stringLiteral0574E31B2E15797E57C51DEC554AE14E00CCB9CC;
IL2CPP_EXTERN_C String_t* _stringLiteral0FC2A6DFBAD242B7CE1A74ACA9D3224CE2E0163D;
IL2CPP_EXTERN_C String_t* _stringLiteral57186E11345D0E246E80500DE17B8C941EF8A38F;
IL2CPP_EXTERN_C String_t* _stringLiteral706336A4F6F53F903F6BD416474754F528D2A13B;
IL2CPP_EXTERN_C String_t* _stringLiteralC51F74D9F7385459B7E90865166418A267D9A62B;
IL2CPP_EXTERN_C String_t* _stringLiteralD7EA9435CDE6F5B13E32FE646D502752ECCD43DD;
IL2CPP_EXTERN_C const RuntimeMethod* AudioClipPlayable_CreateHandle_m3D3EEAD0F584A14B608579167811E5B0497725D0_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* AudioClipPlayable_Create_mFDDE873B2BE8D1F691F19E91799DEB178A54BA0D_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* AudioClipPlayable_Equals_m9C1C75ACBB74FE06AD02BE4643F6EB39413EFF83_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* AudioClipPlayable_GetHandle_mEA1D664328FF9B08E4F7D5EBCD4B51A754D97C44_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* AudioClipPlayable_Seek_m2AB327B535C677793BBADEA634B7AAC9442B1391_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* AudioClipPlayable_SetSpatialBlend_m72F1B86E4E5940E8587C1EA32BB48463A00810BB_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* AudioClipPlayable_SetStereoPan_mB8403E93B06B2ECCD0D4D6B0D55C151D0CCCC494_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* AudioClipPlayable_SetVolume_m3553EC43CBA43CA7802292710A1A284A6DEF8FCC_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* AudioClipPlayable__ctor_m4E686B92CFA7C6A36AA794B1E8C36B1E60605751_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* AudioClipPlayable_op_Explicit_m9A454352B526041DF081B09541EDA59E5190D7AB_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* AudioClipPlayable_op_Implicit_m22CDBB0717207ECCA3892A6281B565246EC2471B_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* AudioClip_InvokePCMReaderCallback_Internal_m766E5705AB5AE16F5F142867CC3758ABE4BF462C_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* AudioClip_InvokePCMSetPositionCallback_Internal_m986EF703B7DDE42343730DE93A095D05B9F4DBB8_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* AudioMixerPlayable_CreateHandle_m8D8F9B1AD8C50F1B441F403E16FFCFF60449CBD4_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* AudioMixerPlayable_Create_m026262C8CC01A49EF65B12B37ADD386D7666C230_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* AudioMixerPlayable_Equals_mDFB945EB48199A338BAD00D40FB8EEC34CF64D57_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* AudioMixerPlayable_GetHandle_m6C182D9794E901D123223BB57738A302BEAB41FD_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* AudioMixerPlayable__ctor_m2CDDE33FCE0B3F7D9EB482D76515FBF771285F47_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* AudioMixerPlayable_op_Implicit_m086F43C4E2E38F40AD37C0F3FF9262A84122BF3B_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* AudioPlayableBinding_CreateAudioOutput_m94A81E9E8FC663985A4507892C6B19DD34A7DBA5_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* AudioPlayableBinding_Create_mDB746897B08554CCDF9FB4367861DAF364031FBF_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* AudioPlayableOutput_Create_mD99F7F05DC16052F2BD5A268CD4880FC1AF20E83_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* AudioPlayableOutput_GetHandle_m55153D572F8FB9BCFF3843402A20280273B934AE_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* AudioPlayableOutput_SetEvaluateOnSeek_mB3266A8A68E94933A82A0C431B7A2E7321929D92_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* AudioPlayableOutput_SetTarget_m34EE86E5C2833F12993681ABE5AC85961836DE04_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* AudioPlayableOutput__ctor_mBEA3D7EE652908558720EDC0D40F7BF3EC50D409_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* AudioPlayableOutput_get_Null_mFCED339CCA2255F4E9AB256BEEB19E0374AA16F3_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* AudioPlayableOutput_op_Explicit_m9E8EE0C49D33D0BF5749858B388D9B42F885FCAC_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* AudioPlayableOutput_op_Implicit_m547B5B8A78353B77C7597270CE50AD3E748A1343_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* AudioSampleProvider_InvokeSampleFramesAvailable_mEB16F7230AB65A3576BF053AC5719F8E134FBCD4_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* AudioSampleProvider_InvokeSampleFramesOverflow_m66593173A527981F5EB2A5EF77B0C9119DAB5E15_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* AudioSettings_InvokeOnAudioConfigurationChanged_m68920E152749F71573C3D10E20967B1850B6EFD8_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* AudioSettings_InvokeOnAudioSystemShuttingDown_mFD616504DB4E06637332C1E0AF38485F114B1335_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* AudioSettings_InvokeOnAudioSystemStartedUp_mD0A9BBF2123B903815EEB7099FB60C9141A146A9_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* PlayableExtensions_SetDuration_TisAudioClipPlayable_tD4B758E68CAE03CB0CD31F90C8A3E603B97143A0_m9A34D349E499987930B568EFE7C9A3F0B8AD47BC_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* PlayableHandle_IsPlayableOfType_TisAudioClipPlayable_tD4B758E68CAE03CB0CD31F90C8A3E603B97143A0_m95809D16DD3494AEB0E9E652B42E0CE3167BEE0E_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* PlayableHandle_IsPlayableOfType_TisAudioMixerPlayable_t6AADDF0C53DF1B4C17969EC24B3B4E4975F3A56C_m28F89BE3D7CCE69B28258CC5B1C7D4E814F48CAB_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* PlayableOutputHandle_IsPlayableOutputOfType_TisAudioPlayableOutput_tC3DFF8095F429D90129A367EAB98A24F6D6ADF20_mAC4BC6AF8D183B1A972EA239A6D9BEA34054C7C6_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeType* AudioClipPlayable_tD4B758E68CAE03CB0CD31F90C8A3E603B97143A0_0_0_0_var;
IL2CPP_EXTERN_C const RuntimeType* AudioClip_t5D272C4EB4F2D3ED49F1C346DEA373CF6D585F20_0_0_0_var;
IL2CPP_EXTERN_C const RuntimeType* AudioMixerPlayable_t6AADDF0C53DF1B4C17969EC24B3B4E4975F3A56C_0_0_0_var;
IL2CPP_EXTERN_C const RuntimeType* AudioPlayableOutput_tC3DFF8095F429D90129A367EAB98A24F6D6ADF20_0_0_0_var;
IL2CPP_EXTERN_C const RuntimeType* AudioSampleProvider_t602353124A2F6F2AEC38E56C3C21932344F712E2_0_0_0_var;
IL2CPP_EXTERN_C const RuntimeType* AudioSource_t871AC2272F896738252F04EE949AEF5B241D3299_0_0_0_var;
IL2CPP_EXTERN_C const RuntimeType* Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_0_0_0_var;
IL2CPP_EXTERN_C const RuntimeType* PlayableBinding_tB68B3BAC47F4F4C559640472174D5BEF93CB6AB4_0_0_0_var;
IL2CPP_EXTERN_C const RuntimeType* PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4_0_0_0_var;
IL2CPP_EXTERN_C const RuntimeType* PlayableOutputHandle_tEB217645A8C0356A3AC6F964F283003B9740E883_0_0_0_var;
IL2CPP_EXTERN_C const RuntimeType* PlayableOutput_t2F7C45A58DA3E788EEDDB439549E21CF3FCF3680_0_0_0_var;
IL2CPP_EXTERN_C const RuntimeType* Playable_t95C6B795846BA0C7D96E4DA14897CCCF2554334F_0_0_0_var;
struct Delegate_t_marshaled_com;
struct Delegate_t_marshaled_pinvoke;
struct Exception_t_marshaled_com;
struct Exception_t_marshaled_pinvoke;
struct Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_marshaled_com;

struct DelegateU5BU5D_tC5AB7E8F745616680F337909D3A8E6C722CDF771;
struct SingleU5BU5D_t89DEFE97BCEDB5857010E79ECE0F52CF6E93B87C;

IL2CPP_EXTERN_C_BEGIN
IL2CPP_EXTERN_C_END

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// <Module>
struct U3CModuleU3E_t462BCCFB9B78348533823E0754F65F52A5348F89 
{
};
struct Il2CppArrayBounds;

// UnityEngine.Audio.AudioPlayableBinding
struct AudioPlayableBinding_tCEBDA2DEB832C1B7A2698EC9DAB066F7D6D85D3F  : public RuntimeObject
{
};

// UnityEngine.Audio.AudioPlayableGraphExtensions
struct AudioPlayableGraphExtensions_tFE52BCEBCCE023697BAC3291D42A6659E973F50E  : public RuntimeObject
{
};

// UnityEngine.Experimental.Audio.AudioSampleProvider
struct AudioSampleProvider_t602353124A2F6F2AEC38E56C3C21932344F712E2  : public RuntimeObject
{
	// UnityEngine.Experimental.Audio.AudioSampleProvider/SampleFramesHandler UnityEngine.Experimental.Audio.AudioSampleProvider::sampleFramesAvailable
	SampleFramesHandler_tFE84FF9BBCEFB880D46227188F375BEF680AAA30* ___sampleFramesAvailable_0;
	// UnityEngine.Experimental.Audio.AudioSampleProvider/SampleFramesHandler UnityEngine.Experimental.Audio.AudioSampleProvider::sampleFramesOverflow
	SampleFramesHandler_tFE84FF9BBCEFB880D46227188F375BEF680AAA30* ___sampleFramesOverflow_1;
};

// UnityEngine.AudioSettings
struct AudioSettings_t66C4BCA1E463B061E2EC9063FB882ACED20D47BD  : public RuntimeObject
{
};

struct AudioSettings_t66C4BCA1E463B061E2EC9063FB882ACED20D47BD_StaticFields
{
	// UnityEngine.AudioSettings/AudioConfigurationChangeHandler UnityEngine.AudioSettings::OnAudioConfigurationChanged
	AudioConfigurationChangeHandler_tE071B0CBA3B3A77D3E41F5FCB65B4017885B3177* ___OnAudioConfigurationChanged_0;
	// System.Action UnityEngine.AudioSettings::OnAudioSystemShuttingDown
	Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* ___OnAudioSystemShuttingDown_1;
	// System.Action UnityEngine.AudioSettings::OnAudioSystemStartedUp
	Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* ___OnAudioSystemStartedUp_2;
};

// System.Reflection.MemberInfo
struct MemberInfo_t  : public RuntimeObject
{
};

// System.String
struct String_t  : public RuntimeObject
{
	// System.Int32 System.String::_stringLength
	int32_t ____stringLength_4;
	// System.Char System.String::_firstChar
	Il2CppChar ____firstChar_5;
};

struct String_t_StaticFields
{
	// System.String System.String::Empty
	String_t* ___Empty_6;
};

// System.ValueType
struct ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F  : public RuntimeObject
{
};
// Native definition for P/Invoke marshalling of System.ValueType
struct ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F_marshaled_pinvoke
{
};
// Native definition for COM marshalling of System.ValueType
struct ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F_marshaled_com
{
};

// System.Boolean
struct Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22 
{
	// System.Boolean System.Boolean::m_value
	bool ___m_value_0;
};

struct Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_StaticFields
{
	// System.String System.Boolean::TrueString
	String_t* ___TrueString_5;
	// System.String System.Boolean::FalseString
	String_t* ___FalseString_6;
};

// System.Double
struct Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F 
{
	// System.Double System.Double::m_value
	double ___m_value_0;
};

// System.Int32
struct Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C 
{
	// System.Int32 System.Int32::m_value
	int32_t ___m_value_0;
};

// System.IntPtr
struct IntPtr_t 
{
	// System.Void* System.IntPtr::m_value
	void* ___m_value_0;
};

struct IntPtr_t_StaticFields
{
	// System.IntPtr System.IntPtr::Zero
	intptr_t ___Zero_1;
};

// System.Single
struct Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C 
{
	// System.Single System.Single::m_value
	float ___m_value_0;
};

// System.UInt32
struct UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B 
{
	// System.UInt32 System.UInt32::m_value
	uint32_t ___m_value_0;
};

// System.Void
struct Void_t4861ACF8F4594C3437BB48B6E56783494B843915 
{
	union
	{
		struct
		{
		};
		uint8_t Void_t4861ACF8F4594C3437BB48B6E56783494B843915__padding[1];
	};
};

// System.Delegate
struct Delegate_t  : public RuntimeObject
{
	// System.IntPtr System.Delegate::method_ptr
	Il2CppMethodPointer ___method_ptr_0;
	// System.IntPtr System.Delegate::invoke_impl
	intptr_t ___invoke_impl_1;
	// System.Object System.Delegate::m_target
	RuntimeObject* ___m_target_2;
	// System.IntPtr System.Delegate::method
	intptr_t ___method_3;
	// System.IntPtr System.Delegate::delegate_trampoline
	intptr_t ___delegate_trampoline_4;
	// System.IntPtr System.Delegate::extra_arg
	intptr_t ___extra_arg_5;
	// System.IntPtr System.Delegate::method_code
	intptr_t ___method_code_6;
	// System.IntPtr System.Delegate::interp_method
	intptr_t ___interp_method_7;
	// System.IntPtr System.Delegate::interp_invoke_impl
	intptr_t ___interp_invoke_impl_8;
	// System.Reflection.MethodInfo System.Delegate::method_info
	MethodInfo_t* ___method_info_9;
	// System.Reflection.MethodInfo System.Delegate::original_method_info
	MethodInfo_t* ___original_method_info_10;
	// System.DelegateData System.Delegate::data
	DelegateData_t9B286B493293CD2D23A5B2B5EF0E5B1324C2B77E* ___data_11;
	// System.Boolean System.Delegate::method_is_virtual
	bool ___method_is_virtual_12;
};
// Native definition for P/Invoke marshalling of System.Delegate
struct Delegate_t_marshaled_pinvoke
{
	intptr_t ___method_ptr_0;
	intptr_t ___invoke_impl_1;
	Il2CppIUnknown* ___m_target_2;
	intptr_t ___method_3;
	intptr_t ___delegate_trampoline_4;
	intptr_t ___extra_arg_5;
	intptr_t ___method_code_6;
	intptr_t ___interp_method_7;
	intptr_t ___interp_invoke_impl_8;
	MethodInfo_t* ___method_info_9;
	MethodInfo_t* ___original_method_info_10;
	DelegateData_t9B286B493293CD2D23A5B2B5EF0E5B1324C2B77E* ___data_11;
	int32_t ___method_is_virtual_12;
};
// Native definition for COM marshalling of System.Delegate
struct Delegate_t_marshaled_com
{
	intptr_t ___method_ptr_0;
	intptr_t ___invoke_impl_1;
	Il2CppIUnknown* ___m_target_2;
	intptr_t ___method_3;
	intptr_t ___delegate_trampoline_4;
	intptr_t ___extra_arg_5;
	intptr_t ___method_code_6;
	intptr_t ___interp_method_7;
	intptr_t ___interp_invoke_impl_8;
	MethodInfo_t* ___method_info_9;
	MethodInfo_t* ___original_method_info_10;
	DelegateData_t9B286B493293CD2D23A5B2B5EF0E5B1324C2B77E* ___data_11;
	int32_t ___method_is_virtual_12;
};

// System.Exception
struct Exception_t  : public RuntimeObject
{
	// System.String System.Exception::_className
	String_t* ____className_1;
	// System.String System.Exception::_message
	String_t* ____message_2;
	// System.Collections.IDictionary System.Exception::_data
	RuntimeObject* ____data_3;
	// System.Exception System.Exception::_innerException
	Exception_t* ____innerException_4;
	// System.String System.Exception::_helpURL
	String_t* ____helpURL_5;
	// System.Object System.Exception::_stackTrace
	RuntimeObject* ____stackTrace_6;
	// System.String System.Exception::_stackTraceString
	String_t* ____stackTraceString_7;
	// System.String System.Exception::_remoteStackTraceString
	String_t* ____remoteStackTraceString_8;
	// System.Int32 System.Exception::_remoteStackIndex
	int32_t ____remoteStackIndex_9;
	// System.Object System.Exception::_dynamicMethods
	RuntimeObject* ____dynamicMethods_10;
	// System.Int32 System.Exception::_HResult
	int32_t ____HResult_11;
	// System.String System.Exception::_source
	String_t* ____source_12;
	// System.Runtime.Serialization.SafeSerializationManager System.Exception::_safeSerializationManager
	SafeSerializationManager_tCBB85B95DFD1634237140CD892E82D06ECB3F5E6* ____safeSerializationManager_13;
	// System.Diagnostics.StackTrace[] System.Exception::captured_traces
	StackTraceU5BU5D_t32FBCB20930EAF5BAE3F450FF75228E5450DA0DF* ___captured_traces_14;
	// System.IntPtr[] System.Exception::native_trace_ips
	IntPtrU5BU5D_tFD177F8C806A6921AD7150264CCC62FA00CAD832* ___native_trace_ips_15;
	// System.Int32 System.Exception::caught_in_unmanaged
	int32_t ___caught_in_unmanaged_16;
};

struct Exception_t_StaticFields
{
	// System.Object System.Exception::s_EDILock
	RuntimeObject* ___s_EDILock_0;
};
// Native definition for P/Invoke marshalling of System.Exception
struct Exception_t_marshaled_pinvoke
{
	char* ____className_1;
	char* ____message_2;
	RuntimeObject* ____data_3;
	Exception_t_marshaled_pinvoke* ____innerException_4;
	char* ____helpURL_5;
	Il2CppIUnknown* ____stackTrace_6;
	char* ____stackTraceString_7;
	char* ____remoteStackTraceString_8;
	int32_t ____remoteStackIndex_9;
	Il2CppIUnknown* ____dynamicMethods_10;
	int32_t ____HResult_11;
	char* ____source_12;
	SafeSerializationManager_tCBB85B95DFD1634237140CD892E82D06ECB3F5E6* ____safeSerializationManager_13;
	StackTraceU5BU5D_t32FBCB20930EAF5BAE3F450FF75228E5450DA0DF* ___captured_traces_14;
	Il2CppSafeArray/*NONE*/* ___native_trace_ips_15;
	int32_t ___caught_in_unmanaged_16;
};
// Native definition for COM marshalling of System.Exception
struct Exception_t_marshaled_com
{
	Il2CppChar* ____className_1;
	Il2CppChar* ____message_2;
	RuntimeObject* ____data_3;
	Exception_t_marshaled_com* ____innerException_4;
	Il2CppChar* ____helpURL_5;
	Il2CppIUnknown* ____stackTrace_6;
	Il2CppChar* ____stackTraceString_7;
	Il2CppChar* ____remoteStackTraceString_8;
	int32_t ____remoteStackIndex_9;
	Il2CppIUnknown* ____dynamicMethods_10;
	int32_t ____HResult_11;
	Il2CppChar* ____source_12;
	SafeSerializationManager_tCBB85B95DFD1634237140CD892E82D06ECB3F5E6* ____safeSerializationManager_13;
	StackTraceU5BU5D_t32FBCB20930EAF5BAE3F450FF75228E5450DA0DF* ___captured_traces_14;
	Il2CppSafeArray/*NONE*/* ___native_trace_ips_15;
	int32_t ___caught_in_unmanaged_16;
};

// UnityEngine.Object
struct Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C  : public RuntimeObject
{
	// System.IntPtr UnityEngine.Object::m_CachedPtr
	intptr_t ___m_CachedPtr_0;
};

struct Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_StaticFields
{
	// System.Int32 UnityEngine.Object::OffsetOfInstanceIDInCPlusPlusObject
	int32_t ___OffsetOfInstanceIDInCPlusPlusObject_1;
};
// Native definition for P/Invoke marshalling of UnityEngine.Object
struct Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_marshaled_pinvoke
{
	intptr_t ___m_CachedPtr_0;
};
// Native definition for COM marshalling of UnityEngine.Object
struct Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_marshaled_com
{
	intptr_t ___m_CachedPtr_0;
};

// UnityEngine.Playables.PlayableGraph
struct PlayableGraph_t4A5B0B45343A240F0761574FD7C672E0CFFF7A6E 
{
	// System.IntPtr UnityEngine.Playables.PlayableGraph::m_Handle
	intptr_t ___m_Handle_0;
	// System.UInt32 UnityEngine.Playables.PlayableGraph::m_Version
	uint32_t ___m_Version_1;
};

// UnityEngine.Playables.PlayableHandle
struct PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4 
{
	// System.IntPtr UnityEngine.Playables.PlayableHandle::m_Handle
	intptr_t ___m_Handle_0;
	// System.UInt32 UnityEngine.Playables.PlayableHandle::m_Version
	uint32_t ___m_Version_1;
};

struct PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4_StaticFields
{
	// UnityEngine.Playables.PlayableHandle UnityEngine.Playables.PlayableHandle::m_Null
	PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4 ___m_Null_2;
};

// UnityEngine.Playables.PlayableOutputHandle
struct PlayableOutputHandle_tEB217645A8C0356A3AC6F964F283003B9740E883 
{
	// System.IntPtr UnityEngine.Playables.PlayableOutputHandle::m_Handle
	intptr_t ___m_Handle_0;
	// System.UInt32 UnityEngine.Playables.PlayableOutputHandle::m_Version
	uint32_t ___m_Version_1;
};

struct PlayableOutputHandle_tEB217645A8C0356A3AC6F964F283003B9740E883_StaticFields
{
	// UnityEngine.Playables.PlayableOutputHandle UnityEngine.Playables.PlayableOutputHandle::m_Null
	PlayableOutputHandle_tEB217645A8C0356A3AC6F964F283003B9740E883 ___m_Null_2;
};

// System.RuntimeTypeHandle
struct RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B 
{
	// System.IntPtr System.RuntimeTypeHandle::value
	intptr_t ___value_0;
};

// UnityEngine.AudioClip
struct AudioClip_t5D272C4EB4F2D3ED49F1C346DEA373CF6D585F20  : public Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C
{
	// UnityEngine.AudioClip/PCMReaderCallback UnityEngine.AudioClip::m_PCMReaderCallback
	PCMReaderCallback_t3396D9613664F0AFF65FB91018FD0F901CC16F1E* ___m_PCMReaderCallback_4;
	// UnityEngine.AudioClip/PCMSetPositionCallback UnityEngine.AudioClip::m_PCMSetPositionCallback
	PCMSetPositionCallback_t8D7135A2FB40647CAEC93F5254AD59E18DEB6072* ___m_PCMSetPositionCallback_5;
};

// UnityEngine.Audio.AudioClipPlayable
struct AudioClipPlayable_tD4B758E68CAE03CB0CD31F90C8A3E603B97143A0 
{
	// UnityEngine.Playables.PlayableHandle UnityEngine.Audio.AudioClipPlayable::m_Handle
	PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4 ___m_Handle_0;
};

// UnityEngine.Audio.AudioMixerPlayable
struct AudioMixerPlayable_t6AADDF0C53DF1B4C17969EC24B3B4E4975F3A56C 
{
	// UnityEngine.Playables.PlayableHandle UnityEngine.Audio.AudioMixerPlayable::m_Handle
	PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4 ___m_Handle_0;
};

// UnityEngine.Audio.AudioPlayableOutput
struct AudioPlayableOutput_tC3DFF8095F429D90129A367EAB98A24F6D6ADF20 
{
	// UnityEngine.Playables.PlayableOutputHandle UnityEngine.Audio.AudioPlayableOutput::m_Handle
	PlayableOutputHandle_tEB217645A8C0356A3AC6F964F283003B9740E883 ___m_Handle_0;
};

// UnityEngine.Component
struct Component_t39FBE53E5EFCF4409111FB22C15FF73717632EC3  : public Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C
{
};

// System.MulticastDelegate
struct MulticastDelegate_t  : public Delegate_t
{
	// System.Delegate[] System.MulticastDelegate::delegates
	DelegateU5BU5D_tC5AB7E8F745616680F337909D3A8E6C722CDF771* ___delegates_13;
};
// Native definition for P/Invoke marshalling of System.MulticastDelegate
struct MulticastDelegate_t_marshaled_pinvoke : public Delegate_t_marshaled_pinvoke
{
	Delegate_t_marshaled_pinvoke** ___delegates_13;
};
// Native definition for COM marshalling of System.MulticastDelegate
struct MulticastDelegate_t_marshaled_com : public Delegate_t_marshaled_com
{
	Delegate_t_marshaled_com** ___delegates_13;
};

// UnityEngine.Playables.Playable
struct Playable_t95C6B795846BA0C7D96E4DA14897CCCF2554334F 
{
	// UnityEngine.Playables.PlayableHandle UnityEngine.Playables.Playable::m_Handle
	PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4 ___m_Handle_0;
};

struct Playable_t95C6B795846BA0C7D96E4DA14897CCCF2554334F_StaticFields
{
	// UnityEngine.Playables.Playable UnityEngine.Playables.Playable::m_NullPlayable
	Playable_t95C6B795846BA0C7D96E4DA14897CCCF2554334F ___m_NullPlayable_1;
};

// UnityEngine.Playables.PlayableBinding
struct PlayableBinding_tB68B3BAC47F4F4C559640472174D5BEF93CB6AB4 
{
	// System.String UnityEngine.Playables.PlayableBinding::m_StreamName
	String_t* ___m_StreamName_0;
	// UnityEngine.Object UnityEngine.Playables.PlayableBinding::m_SourceObject
	Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C* ___m_SourceObject_1;
	// System.Type UnityEngine.Playables.PlayableBinding::m_SourceBindingType
	Type_t* ___m_SourceBindingType_2;
	// UnityEngine.Playables.PlayableBinding/CreateOutputMethod UnityEngine.Playables.PlayableBinding::m_CreateOutputMethod
	CreateOutputMethod_tD18AFE3B69E6DDD913D82D5FA1D5D909CEEC8509* ___m_CreateOutputMethod_3;
};

struct PlayableBinding_tB68B3BAC47F4F4C559640472174D5BEF93CB6AB4_StaticFields
{
	// UnityEngine.Playables.PlayableBinding[] UnityEngine.Playables.PlayableBinding::None
	PlayableBindingU5BU5D_tC50C3F27A8E4246488F7A5998CAABAC4811A92CD* ___None_4;
	// System.Double UnityEngine.Playables.PlayableBinding::DefaultDuration
	double ___DefaultDuration_5;
};
// Native definition for P/Invoke marshalling of UnityEngine.Playables.PlayableBinding
struct PlayableBinding_tB68B3BAC47F4F4C559640472174D5BEF93CB6AB4_marshaled_pinvoke
{
	char* ___m_StreamName_0;
	Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_marshaled_pinvoke ___m_SourceObject_1;
	Type_t* ___m_SourceBindingType_2;
	Il2CppMethodPointer ___m_CreateOutputMethod_3;
};
// Native definition for COM marshalling of UnityEngine.Playables.PlayableBinding
struct PlayableBinding_tB68B3BAC47F4F4C559640472174D5BEF93CB6AB4_marshaled_com
{
	Il2CppChar* ___m_StreamName_0;
	Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_marshaled_com* ___m_SourceObject_1;
	Type_t* ___m_SourceBindingType_2;
	Il2CppMethodPointer ___m_CreateOutputMethod_3;
};

// UnityEngine.Playables.PlayableOutput
struct PlayableOutput_t2F7C45A58DA3E788EEDDB439549E21CF3FCF3680 
{
	// UnityEngine.Playables.PlayableOutputHandle UnityEngine.Playables.PlayableOutput::m_Handle
	PlayableOutputHandle_tEB217645A8C0356A3AC6F964F283003B9740E883 ___m_Handle_0;
};

struct PlayableOutput_t2F7C45A58DA3E788EEDDB439549E21CF3FCF3680_StaticFields
{
	// UnityEngine.Playables.PlayableOutput UnityEngine.Playables.PlayableOutput::m_NullPlayableOutput
	PlayableOutput_t2F7C45A58DA3E788EEDDB439549E21CF3FCF3680 ___m_NullPlayableOutput_1;
};

// System.SystemException
struct SystemException_tCC48D868298F4C0705279823E34B00F4FBDB7295  : public Exception_t
{
};

// System.Type
struct Type_t  : public MemberInfo_t
{
	// System.RuntimeTypeHandle System.Type::_impl
	RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B ____impl_8;
};

struct Type_t_StaticFields
{
	// System.Reflection.Binder modreq(System.Runtime.CompilerServices.IsVolatile) System.Type::s_defaultBinder
	Binder_t91BFCE95A7057FADF4D8A1A342AFE52872246235* ___s_defaultBinder_0;
	// System.Char System.Type::Delimiter
	Il2CppChar ___Delimiter_1;
	// System.Type[] System.Type::EmptyTypes
	TypeU5BU5D_t97234E1129B564EB38B8D85CAC2AD8B5B9522FFB* ___EmptyTypes_2;
	// System.Object System.Type::Missing
	RuntimeObject* ___Missing_3;
	// System.Reflection.MemberFilter System.Type::FilterAttribute
	MemberFilter_tF644F1AE82F611B677CE1964D5A3277DDA21D553* ___FilterAttribute_4;
	// System.Reflection.MemberFilter System.Type::FilterName
	MemberFilter_tF644F1AE82F611B677CE1964D5A3277DDA21D553* ___FilterName_5;
	// System.Reflection.MemberFilter System.Type::FilterNameIgnoreCase
	MemberFilter_tF644F1AE82F611B677CE1964D5A3277DDA21D553* ___FilterNameIgnoreCase_6;
};

// System.Action
struct Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07  : public MulticastDelegate_t
{
};

// System.ArgumentException
struct ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263  : public SystemException_tCC48D868298F4C0705279823E34B00F4FBDB7295
{
	// System.String System.ArgumentException::_paramName
	String_t* ____paramName_18;
};

// UnityEngine.Behaviour
struct Behaviour_t01970CFBBA658497AE30F311C447DB0440BAB7FA  : public Component_t39FBE53E5EFCF4409111FB22C15FF73717632EC3
{
};

// System.InvalidCastException
struct InvalidCastException_t47FC62F21A3937E814D20381DDACEF240E95AC2E  : public SystemException_tCC48D868298F4C0705279823E34B00F4FBDB7295
{
};

// UnityEngine.AudioClip/PCMReaderCallback
struct PCMReaderCallback_t3396D9613664F0AFF65FB91018FD0F901CC16F1E  : public MulticastDelegate_t
{
};

// UnityEngine.AudioClip/PCMSetPositionCallback
struct PCMSetPositionCallback_t8D7135A2FB40647CAEC93F5254AD59E18DEB6072  : public MulticastDelegate_t
{
};

// UnityEngine.Experimental.Audio.AudioSampleProvider/SampleFramesHandler
struct SampleFramesHandler_tFE84FF9BBCEFB880D46227188F375BEF680AAA30  : public MulticastDelegate_t
{
};

// UnityEngine.AudioSettings/AudioConfigurationChangeHandler
struct AudioConfigurationChangeHandler_tE071B0CBA3B3A77D3E41F5FCB65B4017885B3177  : public MulticastDelegate_t
{
};

// UnityEngine.Playables.PlayableBinding/CreateOutputMethod
struct CreateOutputMethod_tD18AFE3B69E6DDD913D82D5FA1D5D909CEEC8509  : public MulticastDelegate_t
{
};

// UnityEngine.AudioBehaviour
struct AudioBehaviour_t2DC0BEF7B020C952F3D2DA5AAAC88501C7EEB941  : public Behaviour_t01970CFBBA658497AE30F311C447DB0440BAB7FA
{
};

// UnityEngine.AudioListener
struct AudioListener_t1D629CE9BC079C8ECDE8F822616E8A8E319EAE35  : public AudioBehaviour_t2DC0BEF7B020C952F3D2DA5AAAC88501C7EEB941
{
};

// UnityEngine.AudioSource
struct AudioSource_t871AC2272F896738252F04EE949AEF5B241D3299  : public AudioBehaviour_t2DC0BEF7B020C952F3D2DA5AAAC88501C7EEB941
{
};
#ifdef __clang__
#pragma clang diagnostic pop
#endif
// System.Delegate[]
struct DelegateU5BU5D_tC5AB7E8F745616680F337909D3A8E6C722CDF771  : public RuntimeArray
{
	ALIGN_FIELD (8) Delegate_t* m_Items[1];

	inline Delegate_t* GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline Delegate_t** GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, Delegate_t* value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier((void**)m_Items + index, (void*)value);
	}
	inline Delegate_t* GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline Delegate_t** GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, Delegate_t* value)
	{
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier((void**)m_Items + index, (void*)value);
	}
};
// System.Single[]
struct SingleU5BU5D_t89DEFE97BCEDB5857010E79ECE0F52CF6E93B87C  : public RuntimeArray
{
	ALIGN_FIELD (8) float m_Items[1];

	inline float GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline float* GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, float value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
	}
	inline float GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline float* GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, float value)
	{
		m_Items[index] = value;
	}
};


// System.Void UnityEngine.Playables.PlayableExtensions::SetDuration<UnityEngine.Audio.AudioClipPlayable>(U,System.Double)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void PlayableExtensions_SetDuration_TisAudioClipPlayable_tD4B758E68CAE03CB0CD31F90C8A3E603B97143A0_m9A34D349E499987930B568EFE7C9A3F0B8AD47BC_gshared (AudioClipPlayable_tD4B758E68CAE03CB0CD31F90C8A3E603B97143A0 ___playable0, double ___value1, const RuntimeMethod* method) ;
// System.Boolean UnityEngine.Playables.PlayableHandle::IsPlayableOfType<UnityEngine.Audio.AudioClipPlayable>()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool PlayableHandle_IsPlayableOfType_TisAudioClipPlayable_tD4B758E68CAE03CB0CD31F90C8A3E603B97143A0_m95809D16DD3494AEB0E9E652B42E0CE3167BEE0E_gshared (PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4* __this, const RuntimeMethod* method) ;
// System.Boolean UnityEngine.Playables.PlayableHandle::IsPlayableOfType<UnityEngine.Audio.AudioMixerPlayable>()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool PlayableHandle_IsPlayableOfType_TisAudioMixerPlayable_t6AADDF0C53DF1B4C17969EC24B3B4E4975F3A56C_m28F89BE3D7CCE69B28258CC5B1C7D4E814F48CAB_gshared (PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4* __this, const RuntimeMethod* method) ;
// System.Boolean UnityEngine.Playables.PlayableOutputHandle::IsPlayableOutputOfType<UnityEngine.Audio.AudioPlayableOutput>()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool PlayableOutputHandle_IsPlayableOutputOfType_TisAudioPlayableOutput_tC3DFF8095F429D90129A367EAB98A24F6D6ADF20_mAC4BC6AF8D183B1A972EA239A6D9BEA34054C7C6_gshared (PlayableOutputHandle_tEB217645A8C0356A3AC6F964F283003B9740E883* __this, const RuntimeMethod* method) ;

// System.Void UnityEngine.AudioSettings/AudioConfigurationChangeHandler::Invoke(System.Boolean)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void AudioConfigurationChangeHandler_Invoke_m4DC27DD11512481B60071B20284E6886DAE54DE2_inline (AudioConfigurationChangeHandler_tE071B0CBA3B3A77D3E41F5FCB65B4017885B3177* __this, bool ___deviceWasChanged0, const RuntimeMethod* method) ;
// System.Void System.Action::Invoke()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Action_Invoke_m7126A54DACA72B845424072887B5F3A51FC3808E_inline (Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* __this, const RuntimeMethod* method) ;
// System.Void UnityEngine.AudioClip/PCMReaderCallback::Invoke(System.Single[])
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void PCMReaderCallback_Invoke_m76784C690C36B513E2AA5B0E4FD9831B2C7E5152_inline (PCMReaderCallback_t3396D9613664F0AFF65FB91018FD0F901CC16F1E* __this, SingleU5BU5D_t89DEFE97BCEDB5857010E79ECE0F52CF6E93B87C* ___data0, const RuntimeMethod* method) ;
// System.Void UnityEngine.AudioClip/PCMSetPositionCallback::Invoke(System.Int32)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void PCMSetPositionCallback_Invoke_m434D4F02FA25F91DF6199EC5A799C551C7F93702_inline (PCMSetPositionCallback_t8D7135A2FB40647CAEC93F5254AD59E18DEB6072* __this, int32_t ___position0, const RuntimeMethod* method) ;
// UnityEngine.Playables.PlayableHandle UnityEngine.Audio.AudioClipPlayable::CreateHandle(UnityEngine.Playables.PlayableGraph,UnityEngine.AudioClip,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4 AudioClipPlayable_CreateHandle_m3D3EEAD0F584A14B608579167811E5B0497725D0 (PlayableGraph_t4A5B0B45343A240F0761574FD7C672E0CFFF7A6E ___graph0, AudioClip_t5D272C4EB4F2D3ED49F1C346DEA373CF6D585F20* ___clip1, bool ___looping2, const RuntimeMethod* method) ;
// System.Void UnityEngine.Audio.AudioClipPlayable::.ctor(UnityEngine.Playables.PlayableHandle)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AudioClipPlayable__ctor_m4E686B92CFA7C6A36AA794B1E8C36B1E60605751 (AudioClipPlayable_tD4B758E68CAE03CB0CD31F90C8A3E603B97143A0* __this, PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4 ___handle0, const RuntimeMethod* method) ;
// System.Boolean UnityEngine.Object::op_Inequality(UnityEngine.Object,UnityEngine.Object)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Object_op_Inequality_m4D656395C27694A7F33F5AA8DE80A7AAF9E20BA7 (Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C* ___x0, Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C* ___y1, const RuntimeMethod* method) ;
// System.Single UnityEngine.AudioClip::get_length()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float AudioClip_get_length_m6102CB29AF65988797452E4D6E43D4788303873D (AudioClip_t5D272C4EB4F2D3ED49F1C346DEA373CF6D585F20* __this, const RuntimeMethod* method) ;
// System.Void UnityEngine.Playables.PlayableExtensions::SetDuration<UnityEngine.Audio.AudioClipPlayable>(U,System.Double)
inline void PlayableExtensions_SetDuration_TisAudioClipPlayable_tD4B758E68CAE03CB0CD31F90C8A3E603B97143A0_m9A34D349E499987930B568EFE7C9A3F0B8AD47BC (AudioClipPlayable_tD4B758E68CAE03CB0CD31F90C8A3E603B97143A0 ___playable0, double ___value1, const RuntimeMethod* method)
{
	((  void (*) (AudioClipPlayable_tD4B758E68CAE03CB0CD31F90C8A3E603B97143A0, double, const RuntimeMethod*))PlayableExtensions_SetDuration_TisAudioClipPlayable_tD4B758E68CAE03CB0CD31F90C8A3E603B97143A0_m9A34D349E499987930B568EFE7C9A3F0B8AD47BC_gshared)(___playable0, ___value1, method);
}
// UnityEngine.Playables.PlayableHandle UnityEngine.Playables.PlayableHandle::get_Null()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4 PlayableHandle_get_Null_m32D9E05C019AC0153C26392C7946F0A1654D1217 (const RuntimeMethod* method) ;
// System.Boolean UnityEngine.Audio.AudioClipPlayable::InternalCreateAudioClipPlayable(UnityEngine.Playables.PlayableGraph&,UnityEngine.AudioClip,System.Boolean,UnityEngine.Playables.PlayableHandle&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool AudioClipPlayable_InternalCreateAudioClipPlayable_mB182B6257F637BFE9C0DAEA9656E747CB240AD2C (PlayableGraph_t4A5B0B45343A240F0761574FD7C672E0CFFF7A6E* ___graph0, AudioClip_t5D272C4EB4F2D3ED49F1C346DEA373CF6D585F20* ___clip1, bool ___looping2, PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4* ___handle3, const RuntimeMethod* method) ;
// System.Boolean UnityEngine.Playables.PlayableHandle::IsValid()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool PlayableHandle_IsValid_m07631D12846BAAF2CC302E69A28A44BFE9EB5098 (PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4* __this, const RuntimeMethod* method) ;
// System.Boolean UnityEngine.Playables.PlayableHandle::IsPlayableOfType<UnityEngine.Audio.AudioClipPlayable>()
inline bool PlayableHandle_IsPlayableOfType_TisAudioClipPlayable_tD4B758E68CAE03CB0CD31F90C8A3E603B97143A0_m95809D16DD3494AEB0E9E652B42E0CE3167BEE0E (PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4* __this, const RuntimeMethod* method)
{
	return ((  bool (*) (PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4*, const RuntimeMethod*))PlayableHandle_IsPlayableOfType_TisAudioClipPlayable_tD4B758E68CAE03CB0CD31F90C8A3E603B97143A0_m95809D16DD3494AEB0E9E652B42E0CE3167BEE0E_gshared)(__this, method);
}
// System.Void System.InvalidCastException::.ctor(System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void InvalidCastException__ctor_mED3F9781E6CA47A92C602C896EDDF2F40ECB8644 (InvalidCastException_t47FC62F21A3937E814D20381DDACEF240E95AC2E* __this, String_t* ___message0, const RuntimeMethod* method) ;
// UnityEngine.Playables.PlayableHandle UnityEngine.Audio.AudioClipPlayable::GetHandle()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4 AudioClipPlayable_GetHandle_mEA1D664328FF9B08E4F7D5EBCD4B51A754D97C44 (AudioClipPlayable_tD4B758E68CAE03CB0CD31F90C8A3E603B97143A0* __this, const RuntimeMethod* method) ;
// System.Void UnityEngine.Playables.Playable::.ctor(UnityEngine.Playables.PlayableHandle)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Playable__ctor_mD2EB35E024816AEED68795D0124EAB30E05BF6C4 (Playable_t95C6B795846BA0C7D96E4DA14897CCCF2554334F* __this, PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4 ___handle0, const RuntimeMethod* method) ;
// UnityEngine.Playables.PlayableHandle UnityEngine.Playables.Playable::GetHandle()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4 Playable_GetHandle_m39356D23E849DC5428B262092657662C064E04F8 (Playable_t95C6B795846BA0C7D96E4DA14897CCCF2554334F* __this, const RuntimeMethod* method) ;
// System.Boolean UnityEngine.Playables.PlayableHandle::op_Equality(UnityEngine.Playables.PlayableHandle,UnityEngine.Playables.PlayableHandle)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool PlayableHandle_op_Equality_m5E9B847A9D36875C78902727FE36FBEDA4D2D3B9 (PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4 ___x0, PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4 ___y1, const RuntimeMethod* method) ;
// System.Boolean UnityEngine.Audio.AudioClipPlayable::Equals(UnityEngine.Audio.AudioClipPlayable)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool AudioClipPlayable_Equals_m9C1C75ACBB74FE06AD02BE4643F6EB39413EFF83 (AudioClipPlayable_tD4B758E68CAE03CB0CD31F90C8A3E603B97143A0* __this, AudioClipPlayable_tD4B758E68CAE03CB0CD31F90C8A3E603B97143A0 ___other0, const RuntimeMethod* method) ;
// System.String System.Single::ToString()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* Single_ToString_mE282EDA9CA4F7DF88432D807732837A629D04972 (float* __this, const RuntimeMethod* method) ;
// System.String System.String::Concat(System.String,System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* String_Concat_mAF2CE02CC0CB7460753D0A1A91CCF2B1E9804C5D (String_t* ___str00, String_t* ___str11, const RuntimeMethod* method) ;
// System.Void System.ArgumentException::.ctor(System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ArgumentException__ctor_m026938A67AF9D36BB7ED27F80425D7194B514465 (ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* __this, String_t* ___message0, const RuntimeMethod* method) ;
// System.Void UnityEngine.Audio.AudioClipPlayable::SetVolumeInternal(UnityEngine.Playables.PlayableHandle&,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AudioClipPlayable_SetVolumeInternal_mA0A7BCFDD9F1E0761AEFD71C2EA0CBD96B7B069B (PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4* ___hdl0, float ___volume1, const RuntimeMethod* method) ;
// System.Void UnityEngine.Audio.AudioClipPlayable::SetVolume(System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AudioClipPlayable_SetVolume_m3553EC43CBA43CA7802292710A1A284A6DEF8FCC (AudioClipPlayable_tD4B758E68CAE03CB0CD31F90C8A3E603B97143A0* __this, float ___value0, const RuntimeMethod* method) ;
// System.Void UnityEngine.Audio.AudioClipPlayable::SetStereoPanInternal(UnityEngine.Playables.PlayableHandle&,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AudioClipPlayable_SetStereoPanInternal_m948B61F4B67962F30C758AF034C6485A38EE5E53 (PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4* ___hdl0, float ___stereoPan1, const RuntimeMethod* method) ;
// System.Void UnityEngine.Audio.AudioClipPlayable::SetStereoPan(System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AudioClipPlayable_SetStereoPan_mB8403E93B06B2ECCD0D4D6B0D55C151D0CCCC494 (AudioClipPlayable_tD4B758E68CAE03CB0CD31F90C8A3E603B97143A0* __this, float ___value0, const RuntimeMethod* method) ;
// System.Void UnityEngine.Audio.AudioClipPlayable::SetSpatialBlendInternal(UnityEngine.Playables.PlayableHandle&,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AudioClipPlayable_SetSpatialBlendInternal_m7BEEE6E7D5C276BD591F7103777610CFAFDE364F (PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4* ___hdl0, float ___spatialBlend1, const RuntimeMethod* method) ;
// System.Void UnityEngine.Audio.AudioClipPlayable::SetSpatialBlend(System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AudioClipPlayable_SetSpatialBlend_m72F1B86E4E5940E8587C1EA32BB48463A00810BB (AudioClipPlayable_tD4B758E68CAE03CB0CD31F90C8A3E603B97143A0* __this, float ___value0, const RuntimeMethod* method) ;
// System.Void UnityEngine.Audio.AudioClipPlayable::SetStartDelayInternal(UnityEngine.Playables.PlayableHandle&,System.Double)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AudioClipPlayable_SetStartDelayInternal_mC4222F4234A7414E77D08E4E9E1CF25990FF38F5 (PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4* ___hdl0, double ___delay1, const RuntimeMethod* method) ;
// System.Void UnityEngine.Playables.PlayableHandle::SetDuration(System.Double)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void PlayableHandle_SetDuration_m4E07F9F3A90B2F3CE10325D9F405993F03CCA08B (PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4* __this, double ___value0, const RuntimeMethod* method) ;
// System.Void UnityEngine.Audio.AudioClipPlayable::SetPauseDelayInternal(UnityEngine.Playables.PlayableHandle&,System.Double)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AudioClipPlayable_SetPauseDelayInternal_m58071C3C9A03DEB0B4D9F3D43367CE1F0F11AB32 (PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4* ___hdl0, double ___delay1, const RuntimeMethod* method) ;
// System.Void UnityEngine.Playables.PlayableHandle::SetTime(System.Double)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void PlayableHandle_SetTime_m6D255AB6779F3DC278813F1C016FE4EBC9F4B1E4 (PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4* __this, double ___value0, const RuntimeMethod* method) ;
// System.Void UnityEngine.Playables.PlayableHandle::Play()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void PlayableHandle_Play_m1EF8E1105EB6A4A9B0D6638A57CDCBCEEDC6FB2D (PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4* __this, const RuntimeMethod* method) ;
// System.Void UnityEngine.Audio.AudioClipPlayable::Seek(System.Double,System.Double,System.Double)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AudioClipPlayable_Seek_m2AB327B535C677793BBADEA634B7AAC9442B1391 (AudioClipPlayable_tD4B758E68CAE03CB0CD31F90C8A3E603B97143A0* __this, double ___startTime0, double ___startDelay1, double ___duration2, const RuntimeMethod* method) ;
// UnityEngine.Playables.PlayableHandle UnityEngine.Audio.AudioMixerPlayable::CreateHandle(UnityEngine.Playables.PlayableGraph,System.Int32,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4 AudioMixerPlayable_CreateHandle_m8D8F9B1AD8C50F1B441F403E16FFCFF60449CBD4 (PlayableGraph_t4A5B0B45343A240F0761574FD7C672E0CFFF7A6E ___graph0, int32_t ___inputCount1, bool ___normalizeInputVolumes2, const RuntimeMethod* method) ;
// System.Void UnityEngine.Audio.AudioMixerPlayable::.ctor(UnityEngine.Playables.PlayableHandle)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AudioMixerPlayable__ctor_m2CDDE33FCE0B3F7D9EB482D76515FBF771285F47 (AudioMixerPlayable_t6AADDF0C53DF1B4C17969EC24B3B4E4975F3A56C* __this, PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4 ___handle0, const RuntimeMethod* method) ;
// System.Boolean UnityEngine.Audio.AudioMixerPlayable::CreateAudioMixerPlayableInternal(UnityEngine.Playables.PlayableGraph&,System.Boolean,UnityEngine.Playables.PlayableHandle&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool AudioMixerPlayable_CreateAudioMixerPlayableInternal_m7DABB246E18952B463177F30CF4BF3933FF1C14B (PlayableGraph_t4A5B0B45343A240F0761574FD7C672E0CFFF7A6E* ___graph0, bool ___normalizeInputVolumes1, PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4* ___handle2, const RuntimeMethod* method) ;
// System.Void UnityEngine.Playables.PlayableHandle::SetInputCount(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void PlayableHandle_SetInputCount_m6067CD3616C428F777903FCBFD789060A2185DEE (PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4* __this, int32_t ___value0, const RuntimeMethod* method) ;
// System.Boolean UnityEngine.Playables.PlayableHandle::IsPlayableOfType<UnityEngine.Audio.AudioMixerPlayable>()
inline bool PlayableHandle_IsPlayableOfType_TisAudioMixerPlayable_t6AADDF0C53DF1B4C17969EC24B3B4E4975F3A56C_m28F89BE3D7CCE69B28258CC5B1C7D4E814F48CAB (PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4* __this, const RuntimeMethod* method)
{
	return ((  bool (*) (PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4*, const RuntimeMethod*))PlayableHandle_IsPlayableOfType_TisAudioMixerPlayable_t6AADDF0C53DF1B4C17969EC24B3B4E4975F3A56C_m28F89BE3D7CCE69B28258CC5B1C7D4E814F48CAB_gshared)(__this, method);
}
// UnityEngine.Playables.PlayableHandle UnityEngine.Audio.AudioMixerPlayable::GetHandle()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4 AudioMixerPlayable_GetHandle_m6C182D9794E901D123223BB57738A302BEAB41FD (AudioMixerPlayable_t6AADDF0C53DF1B4C17969EC24B3B4E4975F3A56C* __this, const RuntimeMethod* method) ;
// System.Boolean UnityEngine.Audio.AudioMixerPlayable::Equals(UnityEngine.Audio.AudioMixerPlayable)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool AudioMixerPlayable_Equals_mDFB945EB48199A338BAD00D40FB8EEC34CF64D57 (AudioMixerPlayable_t6AADDF0C53DF1B4C17969EC24B3B4E4975F3A56C* __this, AudioMixerPlayable_t6AADDF0C53DF1B4C17969EC24B3B4E4975F3A56C ___other0, const RuntimeMethod* method) ;
// System.Type System.Type::GetTypeFromHandle(System.RuntimeTypeHandle)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Type_t* Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E (RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B ___handle0, const RuntimeMethod* method) ;
// System.Void UnityEngine.Playables.PlayableBinding/CreateOutputMethod::.ctor(System.Object,System.IntPtr)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CreateOutputMethod__ctor_m5A339017CD8ECB0140EB936FD2A5B589B20166B4 (CreateOutputMethod_tD18AFE3B69E6DDD913D82D5FA1D5D909CEEC8509* __this, RuntimeObject* ___object0, intptr_t ___method1, const RuntimeMethod* method) ;
// UnityEngine.Playables.PlayableBinding UnityEngine.Playables.PlayableBinding::CreateInternal(System.String,UnityEngine.Object,System.Type,UnityEngine.Playables.PlayableBinding/CreateOutputMethod)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR PlayableBinding_tB68B3BAC47F4F4C559640472174D5BEF93CB6AB4 PlayableBinding_CreateInternal_m4CAAB6FB532F76FEA5BDD52D855F36BDA35517B3 (String_t* ___name0, Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C* ___sourceObject1, Type_t* ___sourceType2, CreateOutputMethod_tD18AFE3B69E6DDD913D82D5FA1D5D909CEEC8509* ___createFunction3, const RuntimeMethod* method) ;
// UnityEngine.Audio.AudioPlayableOutput UnityEngine.Audio.AudioPlayableOutput::Create(UnityEngine.Playables.PlayableGraph,System.String,UnityEngine.AudioSource)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR AudioPlayableOutput_tC3DFF8095F429D90129A367EAB98A24F6D6ADF20 AudioPlayableOutput_Create_mD99F7F05DC16052F2BD5A268CD4880FC1AF20E83 (PlayableGraph_t4A5B0B45343A240F0761574FD7C672E0CFFF7A6E ___graph0, String_t* ___name1, AudioSource_t871AC2272F896738252F04EE949AEF5B241D3299* ___target2, const RuntimeMethod* method) ;
// UnityEngine.Playables.PlayableOutput UnityEngine.Audio.AudioPlayableOutput::op_Implicit(UnityEngine.Audio.AudioPlayableOutput)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR PlayableOutput_t2F7C45A58DA3E788EEDDB439549E21CF3FCF3680 AudioPlayableOutput_op_Implicit_m547B5B8A78353B77C7597270CE50AD3E748A1343 (AudioPlayableOutput_tC3DFF8095F429D90129A367EAB98A24F6D6ADF20 ___output0, const RuntimeMethod* method) ;
// System.Boolean UnityEngine.Audio.AudioPlayableGraphExtensions::InternalCreateAudioOutput(UnityEngine.Playables.PlayableGraph&,System.String,UnityEngine.Playables.PlayableOutputHandle&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool AudioPlayableGraphExtensions_InternalCreateAudioOutput_mE3DD360DD1A748A03C8AF4E42C7ED919CE87AD6C (PlayableGraph_t4A5B0B45343A240F0761574FD7C672E0CFFF7A6E* ___graph0, String_t* ___name1, PlayableOutputHandle_tEB217645A8C0356A3AC6F964F283003B9740E883* ___handle2, const RuntimeMethod* method) ;
// UnityEngine.Audio.AudioPlayableOutput UnityEngine.Audio.AudioPlayableOutput::get_Null()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR AudioPlayableOutput_tC3DFF8095F429D90129A367EAB98A24F6D6ADF20 AudioPlayableOutput_get_Null_mFCED339CCA2255F4E9AB256BEEB19E0374AA16F3 (const RuntimeMethod* method) ;
// System.Void UnityEngine.Audio.AudioPlayableOutput::.ctor(UnityEngine.Playables.PlayableOutputHandle)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AudioPlayableOutput__ctor_mBEA3D7EE652908558720EDC0D40F7BF3EC50D409 (AudioPlayableOutput_tC3DFF8095F429D90129A367EAB98A24F6D6ADF20* __this, PlayableOutputHandle_tEB217645A8C0356A3AC6F964F283003B9740E883 ___handle0, const RuntimeMethod* method) ;
// System.Void UnityEngine.Audio.AudioPlayableOutput::SetTarget(UnityEngine.AudioSource)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AudioPlayableOutput_SetTarget_m34EE86E5C2833F12993681ABE5AC85961836DE04 (AudioPlayableOutput_tC3DFF8095F429D90129A367EAB98A24F6D6ADF20* __this, AudioSource_t871AC2272F896738252F04EE949AEF5B241D3299* ___value0, const RuntimeMethod* method) ;
// System.Boolean UnityEngine.Playables.PlayableOutputHandle::IsValid()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool PlayableOutputHandle_IsValid_mA94C343D72B72C3B1C7636C93A8DB5EA71691312 (PlayableOutputHandle_tEB217645A8C0356A3AC6F964F283003B9740E883* __this, const RuntimeMethod* method) ;
// System.Boolean UnityEngine.Playables.PlayableOutputHandle::IsPlayableOutputOfType<UnityEngine.Audio.AudioPlayableOutput>()
inline bool PlayableOutputHandle_IsPlayableOutputOfType_TisAudioPlayableOutput_tC3DFF8095F429D90129A367EAB98A24F6D6ADF20_mAC4BC6AF8D183B1A972EA239A6D9BEA34054C7C6 (PlayableOutputHandle_tEB217645A8C0356A3AC6F964F283003B9740E883* __this, const RuntimeMethod* method)
{
	return ((  bool (*) (PlayableOutputHandle_tEB217645A8C0356A3AC6F964F283003B9740E883*, const RuntimeMethod*))PlayableOutputHandle_IsPlayableOutputOfType_TisAudioPlayableOutput_tC3DFF8095F429D90129A367EAB98A24F6D6ADF20_mAC4BC6AF8D183B1A972EA239A6D9BEA34054C7C6_gshared)(__this, method);
}
// UnityEngine.Playables.PlayableOutputHandle UnityEngine.Playables.PlayableOutputHandle::get_Null()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR PlayableOutputHandle_tEB217645A8C0356A3AC6F964F283003B9740E883 PlayableOutputHandle_get_Null_m4ECA1C6CE17D440F3EC5E2FD03E4D59FF20554DE (const RuntimeMethod* method) ;
// UnityEngine.Playables.PlayableOutputHandle UnityEngine.Audio.AudioPlayableOutput::GetHandle()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR PlayableOutputHandle_tEB217645A8C0356A3AC6F964F283003B9740E883 AudioPlayableOutput_GetHandle_m55153D572F8FB9BCFF3843402A20280273B934AE (AudioPlayableOutput_tC3DFF8095F429D90129A367EAB98A24F6D6ADF20* __this, const RuntimeMethod* method) ;
// System.Void UnityEngine.Playables.PlayableOutput::.ctor(UnityEngine.Playables.PlayableOutputHandle)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void PlayableOutput__ctor_m55FBB20EC479F67641835EA48D84A1AB3DF39747 (PlayableOutput_t2F7C45A58DA3E788EEDDB439549E21CF3FCF3680* __this, PlayableOutputHandle_tEB217645A8C0356A3AC6F964F283003B9740E883 ___handle0, const RuntimeMethod* method) ;
// UnityEngine.Playables.PlayableOutputHandle UnityEngine.Playables.PlayableOutput::GetHandle()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR PlayableOutputHandle_tEB217645A8C0356A3AC6F964F283003B9740E883 PlayableOutput_GetHandle_m12FF2889D15884CBEB92A6CB376827EBA5A607BF (PlayableOutput_t2F7C45A58DA3E788EEDDB439549E21CF3FCF3680* __this, const RuntimeMethod* method) ;
// System.Void UnityEngine.Audio.AudioPlayableOutput::InternalSetTarget(UnityEngine.Playables.PlayableOutputHandle&,UnityEngine.AudioSource)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AudioPlayableOutput_InternalSetTarget_m79848832BFF56C8AFFD196E429652449E8DEC7DA (PlayableOutputHandle_tEB217645A8C0356A3AC6F964F283003B9740E883* ___output0, AudioSource_t871AC2272F896738252F04EE949AEF5B241D3299* ___target1, const RuntimeMethod* method) ;
// System.Void UnityEngine.Audio.AudioPlayableOutput::InternalSetEvaluateOnSeek(UnityEngine.Playables.PlayableOutputHandle&,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AudioPlayableOutput_InternalSetEvaluateOnSeek_mBA74AB313B981B267A663D298B89F8113602ECB1 (PlayableOutputHandle_tEB217645A8C0356A3AC6F964F283003B9740E883* ___output0, bool ___value1, const RuntimeMethod* method) ;
// System.Void UnityEngine.Audio.AudioPlayableOutput::SetEvaluateOnSeek(System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AudioPlayableOutput_SetEvaluateOnSeek_mB3266A8A68E94933A82A0C431B7A2E7321929D92 (AudioPlayableOutput_tC3DFF8095F429D90129A367EAB98A24F6D6ADF20* __this, bool ___value0, const RuntimeMethod* method) ;
// System.Void UnityEngine.Experimental.Audio.AudioSampleProvider/SampleFramesHandler::Invoke(UnityEngine.Experimental.Audio.AudioSampleProvider,System.UInt32)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void SampleFramesHandler_Invoke_m478D5645634B8C734E58B59CF7750797FC54F1BC_inline (SampleFramesHandler_tFE84FF9BBCEFB880D46227188F375BEF680AAA30* __this, AudioSampleProvider_t602353124A2F6F2AEC38E56C3C21932344F712E2* ___provider0, uint32_t ___sampleFrameCount1, const RuntimeMethod* method) ;
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void UnityEngine.AudioSettings::InvokeOnAudioConfigurationChanged(System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AudioSettings_InvokeOnAudioConfigurationChanged_m68920E152749F71573C3D10E20967B1850B6EFD8 (bool ___deviceWasChanged0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AudioSettings_InvokeOnAudioConfigurationChanged_m68920E152749F71573C3D10E20967B1850B6EFD8_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AudioSettings_t66C4BCA1E463B061E2EC9063FB882ACED20D47BD_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_0_0_0_var);
		s_Il2CppMethodInitialized = true;
	}
	bool V_0 = false;
	DECLARE_METHOD_PARAMS(methodExecutionContextParameters, (&___deviceWasChanged0));
	DECLARE_METHOD_EXEC_CTX(methodExecutionContext, AudioSettings_InvokeOnAudioConfigurationChanged_m68920E152749F71573C3D10E20967B1850B6EFD8_RuntimeMethod_var, NULL, methodExecutionContextParameters, NULL);
	CHECK_METHOD_ENTRY_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 0));
	CHECK_METHOD_EXIT_SEQ_POINT(methodExitChecker, methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 1));
	{
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 2));
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 3));
		AudioConfigurationChangeHandler_tE071B0CBA3B3A77D3E41F5FCB65B4017885B3177* L_0 = ((AudioSettings_t66C4BCA1E463B061E2EC9063FB882ACED20D47BD_StaticFields*)il2cpp_codegen_static_fields_for(AudioSettings_t66C4BCA1E463B061E2EC9063FB882ACED20D47BD_il2cpp_TypeInfo_var))->___OnAudioConfigurationChanged_0;
		V_0 = (bool)((!(((RuntimeObject*)(AudioConfigurationChangeHandler_tE071B0CBA3B3A77D3E41F5FCB65B4017885B3177*)L_0) <= ((RuntimeObject*)(RuntimeObject*)NULL)))? 1 : 0);
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 4));
		bool L_1 = V_0;
		if (!L_1)
		{
			goto IL_0019;
		}
	}
	{
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 5));
		AudioConfigurationChangeHandler_tE071B0CBA3B3A77D3E41F5FCB65B4017885B3177* L_2 = ((AudioSettings_t66C4BCA1E463B061E2EC9063FB882ACED20D47BD_StaticFields*)il2cpp_codegen_static_fields_for(AudioSettings_t66C4BCA1E463B061E2EC9063FB882ACED20D47BD_il2cpp_TypeInfo_var))->___OnAudioConfigurationChanged_0;
		bool L_3 = ___deviceWasChanged0;
		STORE_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 6));
		NullCheck(L_2);
		AudioConfigurationChangeHandler_Invoke_m4DC27DD11512481B60071B20284E6886DAE54DE2_inline(L_2, L_3, NULL);
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 6));
	}

IL_0019:
	{
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 7));
		return;
	}
}
// System.Void UnityEngine.AudioSettings::InvokeOnAudioSystemShuttingDown()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AudioSettings_InvokeOnAudioSystemShuttingDown_mFD616504DB4E06637332C1E0AF38485F114B1335 (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AudioSettings_InvokeOnAudioSystemShuttingDown_mFD616504DB4E06637332C1E0AF38485F114B1335_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AudioSettings_t66C4BCA1E463B061E2EC9063FB882ACED20D47BD_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	DECLARE_METHOD_EXEC_CTX(methodExecutionContext, AudioSettings_InvokeOnAudioSystemShuttingDown_mFD616504DB4E06637332C1E0AF38485F114B1335_RuntimeMethod_var, NULL, NULL, NULL);
	CHECK_METHOD_ENTRY_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 8));
	CHECK_METHOD_EXIT_SEQ_POINT(methodExitChecker, methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 9));
	Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* G_B2_0 = NULL;
	Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* G_B1_0 = NULL;
	{
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 10));
		Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* L_0 = ((AudioSettings_t66C4BCA1E463B061E2EC9063FB882ACED20D47BD_StaticFields*)il2cpp_codegen_static_fields_for(AudioSettings_t66C4BCA1E463B061E2EC9063FB882ACED20D47BD_il2cpp_TypeInfo_var))->___OnAudioSystemShuttingDown_1;
		Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* L_1 = L_0;
		G_B1_0 = L_1;
		if (L_1)
		{
			G_B2_0 = L_1;
			goto IL_000b;
		}
	}
	{
		goto IL_0011;
	}

IL_000b:
	{
		STORE_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 11));
		NullCheck(G_B2_0);
		Action_Invoke_m7126A54DACA72B845424072887B5F3A51FC3808E_inline(G_B2_0, NULL);
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 11));
	}

IL_0011:
	{
		return;
	}
}
// System.Void UnityEngine.AudioSettings::InvokeOnAudioSystemStartedUp()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AudioSettings_InvokeOnAudioSystemStartedUp_mD0A9BBF2123B903815EEB7099FB60C9141A146A9 (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AudioSettings_InvokeOnAudioSystemStartedUp_mD0A9BBF2123B903815EEB7099FB60C9141A146A9_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AudioSettings_t66C4BCA1E463B061E2EC9063FB882ACED20D47BD_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	DECLARE_METHOD_EXEC_CTX(methodExecutionContext, AudioSettings_InvokeOnAudioSystemStartedUp_mD0A9BBF2123B903815EEB7099FB60C9141A146A9_RuntimeMethod_var, NULL, NULL, NULL);
	CHECK_METHOD_ENTRY_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 12));
	CHECK_METHOD_EXIT_SEQ_POINT(methodExitChecker, methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 13));
	Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* G_B2_0 = NULL;
	Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* G_B1_0 = NULL;
	{
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 14));
		Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* L_0 = ((AudioSettings_t66C4BCA1E463B061E2EC9063FB882ACED20D47BD_StaticFields*)il2cpp_codegen_static_fields_for(AudioSettings_t66C4BCA1E463B061E2EC9063FB882ACED20D47BD_il2cpp_TypeInfo_var))->___OnAudioSystemStartedUp_2;
		Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* L_1 = L_0;
		G_B1_0 = L_1;
		if (L_1)
		{
			G_B2_0 = L_1;
			goto IL_000b;
		}
	}
	{
		goto IL_0011;
	}

IL_000b:
	{
		STORE_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 15));
		NullCheck(G_B2_0);
		Action_Invoke_m7126A54DACA72B845424072887B5F3A51FC3808E_inline(G_B2_0, NULL);
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 15));
	}

IL_0011:
	{
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
void AudioConfigurationChangeHandler_Invoke_m4DC27DD11512481B60071B20284E6886DAE54DE2_Multicast(AudioConfigurationChangeHandler_tE071B0CBA3B3A77D3E41F5FCB65B4017885B3177* __this, bool ___deviceWasChanged0, const RuntimeMethod* method)
{
	il2cpp_array_size_t length = __this->___delegates_13->max_length;
	Delegate_t** delegatesToInvoke = reinterpret_cast<Delegate_t**>(__this->___delegates_13->GetAddressAtUnchecked(0));
	for (il2cpp_array_size_t i = 0; i < length; i++)
	{
		AudioConfigurationChangeHandler_tE071B0CBA3B3A77D3E41F5FCB65B4017885B3177* currentDelegate = reinterpret_cast<AudioConfigurationChangeHandler_tE071B0CBA3B3A77D3E41F5FCB65B4017885B3177*>(delegatesToInvoke[i]);
		typedef void (*FunctionPointerType) (RuntimeObject*, bool, const RuntimeMethod*);
		((FunctionPointerType)currentDelegate->___invoke_impl_1)((Il2CppObject*)currentDelegate->___method_code_6, ___deviceWasChanged0, reinterpret_cast<RuntimeMethod*>(currentDelegate->___method_3));
	}
}
void AudioConfigurationChangeHandler_Invoke_m4DC27DD11512481B60071B20284E6886DAE54DE2_OpenInst(AudioConfigurationChangeHandler_tE071B0CBA3B3A77D3E41F5FCB65B4017885B3177* __this, bool ___deviceWasChanged0, const RuntimeMethod* method)
{
	typedef void (*FunctionPointerType) (bool, const RuntimeMethod*);
	((FunctionPointerType)__this->___method_ptr_0)(___deviceWasChanged0, method);
}
void AudioConfigurationChangeHandler_Invoke_m4DC27DD11512481B60071B20284E6886DAE54DE2_OpenStatic(AudioConfigurationChangeHandler_tE071B0CBA3B3A77D3E41F5FCB65B4017885B3177* __this, bool ___deviceWasChanged0, const RuntimeMethod* method)
{
	typedef void (*FunctionPointerType) (bool, const RuntimeMethod*);
	((FunctionPointerType)__this->___method_ptr_0)(___deviceWasChanged0, method);
}
void AudioConfigurationChangeHandler_Invoke_m4DC27DD11512481B60071B20284E6886DAE54DE2_OpenStaticInvoker(AudioConfigurationChangeHandler_tE071B0CBA3B3A77D3E41F5FCB65B4017885B3177* __this, bool ___deviceWasChanged0, const RuntimeMethod* method)
{
	InvokerActionInvoker1< bool >::Invoke(__this->___method_ptr_0, method, NULL, ___deviceWasChanged0);
}
void AudioConfigurationChangeHandler_Invoke_m4DC27DD11512481B60071B20284E6886DAE54DE2_ClosedStaticInvoker(AudioConfigurationChangeHandler_tE071B0CBA3B3A77D3E41F5FCB65B4017885B3177* __this, bool ___deviceWasChanged0, const RuntimeMethod* method)
{
	InvokerActionInvoker2< RuntimeObject*, bool >::Invoke(__this->___method_ptr_0, method, NULL, __this->___m_target_2, ___deviceWasChanged0);
}
IL2CPP_EXTERN_C  void DelegatePInvokeWrapper_AudioConfigurationChangeHandler_tE071B0CBA3B3A77D3E41F5FCB65B4017885B3177 (AudioConfigurationChangeHandler_tE071B0CBA3B3A77D3E41F5FCB65B4017885B3177* __this, bool ___deviceWasChanged0, const RuntimeMethod* method)
{
	typedef void (DEFAULT_CALL *PInvokeFunc)(int32_t);
	PInvokeFunc il2cppPInvokeFunc = reinterpret_cast<PInvokeFunc>(il2cpp_codegen_get_reverse_pinvoke_function_ptr(__this));
	// Native function invocation
	il2cppPInvokeFunc(static_cast<int32_t>(___deviceWasChanged0));

}
// System.Void UnityEngine.AudioSettings/AudioConfigurationChangeHandler::.ctor(System.Object,System.IntPtr)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AudioConfigurationChangeHandler__ctor_mA9827AB9472EC8EE0A0F0FC24EBC06B4740DD944 (AudioConfigurationChangeHandler_tE071B0CBA3B3A77D3E41F5FCB65B4017885B3177* __this, RuntimeObject* ___object0, intptr_t ___method1, const RuntimeMethod* method) 
{
	__this->___method_ptr_0 = il2cpp_codegen_get_virtual_call_method_pointer((RuntimeMethod*)___method1);
	__this->___method_3 = ___method1;
	__this->___m_target_2 = ___object0;
	Il2CppCodeGenWriteBarrier((void**)(&__this->___m_target_2), (void*)___object0);
	int parameterCount = il2cpp_codegen_method_parameter_count((RuntimeMethod*)___method1);
	__this->___method_code_6 = (intptr_t)__this;
	if (MethodIsStatic((RuntimeMethod*)___method1))
	{
		bool isOpen = parameterCount == 1;
		if (il2cpp_codegen_call_method_via_invoker((RuntimeMethod*)___method1))
			if (isOpen)
				__this->___invoke_impl_1 = (intptr_t)&AudioConfigurationChangeHandler_Invoke_m4DC27DD11512481B60071B20284E6886DAE54DE2_OpenStaticInvoker;
			else
				__this->___invoke_impl_1 = (intptr_t)&AudioConfigurationChangeHandler_Invoke_m4DC27DD11512481B60071B20284E6886DAE54DE2_ClosedStaticInvoker;
		else
			if (isOpen)
				__this->___invoke_impl_1 = (intptr_t)&AudioConfigurationChangeHandler_Invoke_m4DC27DD11512481B60071B20284E6886DAE54DE2_OpenStatic;
			else
				{
					__this->___invoke_impl_1 = (intptr_t)__this->___method_ptr_0;
					__this->___method_code_6 = (intptr_t)__this->___m_target_2;
				}
	}
	else
	{
		if (___object0 == NULL)
			il2cpp_codegen_raise_exception(il2cpp_codegen_get_argument_exception(NULL, "Delegate to an instance method cannot have null 'this'."), NULL);
		__this->___invoke_impl_1 = (intptr_t)__this->___method_ptr_0;
		__this->___method_code_6 = (intptr_t)__this->___m_target_2;
	}
	__this->___extra_arg_5 = (intptr_t)&AudioConfigurationChangeHandler_Invoke_m4DC27DD11512481B60071B20284E6886DAE54DE2_Multicast;
}
// System.Void UnityEngine.AudioSettings/AudioConfigurationChangeHandler::Invoke(System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AudioConfigurationChangeHandler_Invoke_m4DC27DD11512481B60071B20284E6886DAE54DE2 (AudioConfigurationChangeHandler_tE071B0CBA3B3A77D3E41F5FCB65B4017885B3177* __this, bool ___deviceWasChanged0, const RuntimeMethod* method) 
{
	typedef void (*FunctionPointerType) (RuntimeObject*, bool, const RuntimeMethod*);
	((FunctionPointerType)__this->___invoke_impl_1)((Il2CppObject*)__this->___method_code_6, ___deviceWasChanged0, reinterpret_cast<RuntimeMethod*>(__this->___method_3));
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Single UnityEngine.AudioClip::get_length()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float AudioClip_get_length_m6102CB29AF65988797452E4D6E43D4788303873D (AudioClip_t5D272C4EB4F2D3ED49F1C346DEA373CF6D585F20* __this, const RuntimeMethod* method) 
{
	typedef float (*AudioClip_get_length_m6102CB29AF65988797452E4D6E43D4788303873D_ftn) (AudioClip_t5D272C4EB4F2D3ED49F1C346DEA373CF6D585F20*);
	static AudioClip_get_length_m6102CB29AF65988797452E4D6E43D4788303873D_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (AudioClip_get_length_m6102CB29AF65988797452E4D6E43D4788303873D_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.AudioClip::get_length()");
	float icallRetVal = _il2cpp_icall_func(__this);
	return icallRetVal;
}
// System.Int32 UnityEngine.AudioClip::get_samples()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t AudioClip_get_samples_mDEA01CA75E7DEA0F8D480E4AF97FB96085BCF38E (AudioClip_t5D272C4EB4F2D3ED49F1C346DEA373CF6D585F20* __this, const RuntimeMethod* method) 
{
	typedef int32_t (*AudioClip_get_samples_mDEA01CA75E7DEA0F8D480E4AF97FB96085BCF38E_ftn) (AudioClip_t5D272C4EB4F2D3ED49F1C346DEA373CF6D585F20*);
	static AudioClip_get_samples_mDEA01CA75E7DEA0F8D480E4AF97FB96085BCF38E_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (AudioClip_get_samples_mDEA01CA75E7DEA0F8D480E4AF97FB96085BCF38E_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.AudioClip::get_samples()");
	int32_t icallRetVal = _il2cpp_icall_func(__this);
	return icallRetVal;
}
// System.Int32 UnityEngine.AudioClip::get_frequency()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t AudioClip_get_frequency_m6647E10F4B2B1335187B0066E82468CCCF19647B (AudioClip_t5D272C4EB4F2D3ED49F1C346DEA373CF6D585F20* __this, const RuntimeMethod* method) 
{
	typedef int32_t (*AudioClip_get_frequency_m6647E10F4B2B1335187B0066E82468CCCF19647B_ftn) (AudioClip_t5D272C4EB4F2D3ED49F1C346DEA373CF6D585F20*);
	static AudioClip_get_frequency_m6647E10F4B2B1335187B0066E82468CCCF19647B_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (AudioClip_get_frequency_m6647E10F4B2B1335187B0066E82468CCCF19647B_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.AudioClip::get_frequency()");
	int32_t icallRetVal = _il2cpp_icall_func(__this);
	return icallRetVal;
}
// System.Void UnityEngine.AudioClip::InvokePCMReaderCallback_Internal(System.Single[])
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AudioClip_InvokePCMReaderCallback_Internal_m766E5705AB5AE16F5F142867CC3758ABE4BF462C (AudioClip_t5D272C4EB4F2D3ED49F1C346DEA373CF6D585F20* __this, SingleU5BU5D_t89DEFE97BCEDB5857010E79ECE0F52CF6E93B87C* ___data0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AudioClip_InvokePCMReaderCallback_Internal_m766E5705AB5AE16F5F142867CC3758ABE4BF462C_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AudioClip_t5D272C4EB4F2D3ED49F1C346DEA373CF6D585F20_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_0_0_0_var);
		s_Il2CppMethodInitialized = true;
	}
	bool V_0 = false;
	DECLARE_METHOD_THIS(methodExecutionContextThis, (&__this));
	DECLARE_METHOD_PARAMS(methodExecutionContextParameters, (&___data0));
	DECLARE_METHOD_EXEC_CTX(methodExecutionContext, AudioClip_InvokePCMReaderCallback_Internal_m766E5705AB5AE16F5F142867CC3758ABE4BF462C_RuntimeMethod_var, methodExecutionContextThis, methodExecutionContextParameters, NULL);
	CHECK_METHOD_ENTRY_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 16));
	CHECK_METHOD_EXIT_SEQ_POINT(methodExitChecker, methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 17));
	{
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 18));
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 19));
		PCMReaderCallback_t3396D9613664F0AFF65FB91018FD0F901CC16F1E* L_0 = __this->___m_PCMReaderCallback_4;
		V_0 = (bool)((!(((RuntimeObject*)(PCMReaderCallback_t3396D9613664F0AFF65FB91018FD0F901CC16F1E*)L_0) <= ((RuntimeObject*)(RuntimeObject*)NULL)))? 1 : 0);
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 20));
		bool L_1 = V_0;
		if (!L_1)
		{
			goto IL_001b;
		}
	}
	{
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 21));
		PCMReaderCallback_t3396D9613664F0AFF65FB91018FD0F901CC16F1E* L_2 = __this->___m_PCMReaderCallback_4;
		SingleU5BU5D_t89DEFE97BCEDB5857010E79ECE0F52CF6E93B87C* L_3 = ___data0;
		STORE_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 22));
		NullCheck(L_2);
		PCMReaderCallback_Invoke_m76784C690C36B513E2AA5B0E4FD9831B2C7E5152_inline(L_2, L_3, NULL);
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 22));
	}

IL_001b:
	{
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 23));
		return;
	}
}
// System.Void UnityEngine.AudioClip::InvokePCMSetPositionCallback_Internal(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AudioClip_InvokePCMSetPositionCallback_Internal_m986EF703B7DDE42343730DE93A095D05B9F4DBB8 (AudioClip_t5D272C4EB4F2D3ED49F1C346DEA373CF6D585F20* __this, int32_t ___position0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AudioClip_InvokePCMSetPositionCallback_Internal_m986EF703B7DDE42343730DE93A095D05B9F4DBB8_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AudioClip_t5D272C4EB4F2D3ED49F1C346DEA373CF6D585F20_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_0_0_0_var);
		s_Il2CppMethodInitialized = true;
	}
	bool V_0 = false;
	DECLARE_METHOD_THIS(methodExecutionContextThis, (&__this));
	DECLARE_METHOD_PARAMS(methodExecutionContextParameters, (&___position0));
	DECLARE_METHOD_EXEC_CTX(methodExecutionContext, AudioClip_InvokePCMSetPositionCallback_Internal_m986EF703B7DDE42343730DE93A095D05B9F4DBB8_RuntimeMethod_var, methodExecutionContextThis, methodExecutionContextParameters, NULL);
	CHECK_METHOD_ENTRY_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 24));
	CHECK_METHOD_EXIT_SEQ_POINT(methodExitChecker, methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 25));
	{
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 26));
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 27));
		PCMSetPositionCallback_t8D7135A2FB40647CAEC93F5254AD59E18DEB6072* L_0 = __this->___m_PCMSetPositionCallback_5;
		V_0 = (bool)((!(((RuntimeObject*)(PCMSetPositionCallback_t8D7135A2FB40647CAEC93F5254AD59E18DEB6072*)L_0) <= ((RuntimeObject*)(RuntimeObject*)NULL)))? 1 : 0);
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 28));
		bool L_1 = V_0;
		if (!L_1)
		{
			goto IL_001b;
		}
	}
	{
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 29));
		PCMSetPositionCallback_t8D7135A2FB40647CAEC93F5254AD59E18DEB6072* L_2 = __this->___m_PCMSetPositionCallback_5;
		int32_t L_3 = ___position0;
		STORE_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 30));
		NullCheck(L_2);
		PCMSetPositionCallback_Invoke_m434D4F02FA25F91DF6199EC5A799C551C7F93702_inline(L_2, L_3, NULL);
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 30));
	}

IL_001b:
	{
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 31));
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
void PCMReaderCallback_Invoke_m76784C690C36B513E2AA5B0E4FD9831B2C7E5152_Multicast(PCMReaderCallback_t3396D9613664F0AFF65FB91018FD0F901CC16F1E* __this, SingleU5BU5D_t89DEFE97BCEDB5857010E79ECE0F52CF6E93B87C* ___data0, const RuntimeMethod* method)
{
	il2cpp_array_size_t length = __this->___delegates_13->max_length;
	Delegate_t** delegatesToInvoke = reinterpret_cast<Delegate_t**>(__this->___delegates_13->GetAddressAtUnchecked(0));
	for (il2cpp_array_size_t i = 0; i < length; i++)
	{
		PCMReaderCallback_t3396D9613664F0AFF65FB91018FD0F901CC16F1E* currentDelegate = reinterpret_cast<PCMReaderCallback_t3396D9613664F0AFF65FB91018FD0F901CC16F1E*>(delegatesToInvoke[i]);
		typedef void (*FunctionPointerType) (RuntimeObject*, SingleU5BU5D_t89DEFE97BCEDB5857010E79ECE0F52CF6E93B87C*, const RuntimeMethod*);
		((FunctionPointerType)currentDelegate->___invoke_impl_1)((Il2CppObject*)currentDelegate->___method_code_6, ___data0, reinterpret_cast<RuntimeMethod*>(currentDelegate->___method_3));
	}
}
void PCMReaderCallback_Invoke_m76784C690C36B513E2AA5B0E4FD9831B2C7E5152_OpenInst(PCMReaderCallback_t3396D9613664F0AFF65FB91018FD0F901CC16F1E* __this, SingleU5BU5D_t89DEFE97BCEDB5857010E79ECE0F52CF6E93B87C* ___data0, const RuntimeMethod* method)
{
	NullCheck(___data0);
	typedef void (*FunctionPointerType) (SingleU5BU5D_t89DEFE97BCEDB5857010E79ECE0F52CF6E93B87C*, const RuntimeMethod*);
	((FunctionPointerType)__this->___method_ptr_0)(___data0, method);
}
void PCMReaderCallback_Invoke_m76784C690C36B513E2AA5B0E4FD9831B2C7E5152_OpenStatic(PCMReaderCallback_t3396D9613664F0AFF65FB91018FD0F901CC16F1E* __this, SingleU5BU5D_t89DEFE97BCEDB5857010E79ECE0F52CF6E93B87C* ___data0, const RuntimeMethod* method)
{
	typedef void (*FunctionPointerType) (SingleU5BU5D_t89DEFE97BCEDB5857010E79ECE0F52CF6E93B87C*, const RuntimeMethod*);
	((FunctionPointerType)__this->___method_ptr_0)(___data0, method);
}
void PCMReaderCallback_Invoke_m76784C690C36B513E2AA5B0E4FD9831B2C7E5152_OpenStaticInvoker(PCMReaderCallback_t3396D9613664F0AFF65FB91018FD0F901CC16F1E* __this, SingleU5BU5D_t89DEFE97BCEDB5857010E79ECE0F52CF6E93B87C* ___data0, const RuntimeMethod* method)
{
	InvokerActionInvoker1< SingleU5BU5D_t89DEFE97BCEDB5857010E79ECE0F52CF6E93B87C* >::Invoke(__this->___method_ptr_0, method, NULL, ___data0);
}
void PCMReaderCallback_Invoke_m76784C690C36B513E2AA5B0E4FD9831B2C7E5152_ClosedStaticInvoker(PCMReaderCallback_t3396D9613664F0AFF65FB91018FD0F901CC16F1E* __this, SingleU5BU5D_t89DEFE97BCEDB5857010E79ECE0F52CF6E93B87C* ___data0, const RuntimeMethod* method)
{
	InvokerActionInvoker2< RuntimeObject*, SingleU5BU5D_t89DEFE97BCEDB5857010E79ECE0F52CF6E93B87C* >::Invoke(__this->___method_ptr_0, method, NULL, __this->___m_target_2, ___data0);
}
IL2CPP_EXTERN_C  void DelegatePInvokeWrapper_PCMReaderCallback_t3396D9613664F0AFF65FB91018FD0F901CC16F1E (PCMReaderCallback_t3396D9613664F0AFF65FB91018FD0F901CC16F1E* __this, SingleU5BU5D_t89DEFE97BCEDB5857010E79ECE0F52CF6E93B87C* ___data0, const RuntimeMethod* method)
{
	typedef void (DEFAULT_CALL *PInvokeFunc)(float*);
	PInvokeFunc il2cppPInvokeFunc = reinterpret_cast<PInvokeFunc>(il2cpp_codegen_get_reverse_pinvoke_function_ptr(__this));
	// Marshaling of parameter '___data0' to native representation
	float* ____data0_marshaled = NULL;
	if (___data0 != NULL)
	{
		____data0_marshaled = reinterpret_cast<float*>((___data0)->GetAddressAtUnchecked(0));
	}

	// Native function invocation
	il2cppPInvokeFunc(____data0_marshaled);

}
// System.Void UnityEngine.AudioClip/PCMReaderCallback::.ctor(System.Object,System.IntPtr)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void PCMReaderCallback__ctor_mF621B6CC1A4BA6525190C5037401CF2FD5C0CF28 (PCMReaderCallback_t3396D9613664F0AFF65FB91018FD0F901CC16F1E* __this, RuntimeObject* ___object0, intptr_t ___method1, const RuntimeMethod* method) 
{
	__this->___method_ptr_0 = il2cpp_codegen_get_virtual_call_method_pointer((RuntimeMethod*)___method1);
	__this->___method_3 = ___method1;
	__this->___m_target_2 = ___object0;
	Il2CppCodeGenWriteBarrier((void**)(&__this->___m_target_2), (void*)___object0);
	int parameterCount = il2cpp_codegen_method_parameter_count((RuntimeMethod*)___method1);
	__this->___method_code_6 = (intptr_t)__this;
	if (MethodIsStatic((RuntimeMethod*)___method1))
	{
		bool isOpen = parameterCount == 1;
		if (il2cpp_codegen_call_method_via_invoker((RuntimeMethod*)___method1))
			if (isOpen)
				__this->___invoke_impl_1 = (intptr_t)&PCMReaderCallback_Invoke_m76784C690C36B513E2AA5B0E4FD9831B2C7E5152_OpenStaticInvoker;
			else
				__this->___invoke_impl_1 = (intptr_t)&PCMReaderCallback_Invoke_m76784C690C36B513E2AA5B0E4FD9831B2C7E5152_ClosedStaticInvoker;
		else
			if (isOpen)
				__this->___invoke_impl_1 = (intptr_t)&PCMReaderCallback_Invoke_m76784C690C36B513E2AA5B0E4FD9831B2C7E5152_OpenStatic;
			else
				{
					__this->___invoke_impl_1 = (intptr_t)__this->___method_ptr_0;
					__this->___method_code_6 = (intptr_t)__this->___m_target_2;
				}
	}
	else
	{
		bool isOpen = parameterCount == 0;
		if (isOpen)
		{
			__this->___invoke_impl_1 = (intptr_t)&PCMReaderCallback_Invoke_m76784C690C36B513E2AA5B0E4FD9831B2C7E5152_OpenInst;
		}
		else
		{
			if (___object0 == NULL)
				il2cpp_codegen_raise_exception(il2cpp_codegen_get_argument_exception(NULL, "Delegate to an instance method cannot have null 'this'."), NULL);
			__this->___invoke_impl_1 = (intptr_t)__this->___method_ptr_0;
			__this->___method_code_6 = (intptr_t)__this->___m_target_2;
		}
	}
	__this->___extra_arg_5 = (intptr_t)&PCMReaderCallback_Invoke_m76784C690C36B513E2AA5B0E4FD9831B2C7E5152_Multicast;
}
// System.Void UnityEngine.AudioClip/PCMReaderCallback::Invoke(System.Single[])
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void PCMReaderCallback_Invoke_m76784C690C36B513E2AA5B0E4FD9831B2C7E5152 (PCMReaderCallback_t3396D9613664F0AFF65FB91018FD0F901CC16F1E* __this, SingleU5BU5D_t89DEFE97BCEDB5857010E79ECE0F52CF6E93B87C* ___data0, const RuntimeMethod* method) 
{
	typedef void (*FunctionPointerType) (RuntimeObject*, SingleU5BU5D_t89DEFE97BCEDB5857010E79ECE0F52CF6E93B87C*, const RuntimeMethod*);
	((FunctionPointerType)__this->___invoke_impl_1)((Il2CppObject*)__this->___method_code_6, ___data0, reinterpret_cast<RuntimeMethod*>(__this->___method_3));
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
void PCMSetPositionCallback_Invoke_m434D4F02FA25F91DF6199EC5A799C551C7F93702_Multicast(PCMSetPositionCallback_t8D7135A2FB40647CAEC93F5254AD59E18DEB6072* __this, int32_t ___position0, const RuntimeMethod* method)
{
	il2cpp_array_size_t length = __this->___delegates_13->max_length;
	Delegate_t** delegatesToInvoke = reinterpret_cast<Delegate_t**>(__this->___delegates_13->GetAddressAtUnchecked(0));
	for (il2cpp_array_size_t i = 0; i < length; i++)
	{
		PCMSetPositionCallback_t8D7135A2FB40647CAEC93F5254AD59E18DEB6072* currentDelegate = reinterpret_cast<PCMSetPositionCallback_t8D7135A2FB40647CAEC93F5254AD59E18DEB6072*>(delegatesToInvoke[i]);
		typedef void (*FunctionPointerType) (RuntimeObject*, int32_t, const RuntimeMethod*);
		((FunctionPointerType)currentDelegate->___invoke_impl_1)((Il2CppObject*)currentDelegate->___method_code_6, ___position0, reinterpret_cast<RuntimeMethod*>(currentDelegate->___method_3));
	}
}
void PCMSetPositionCallback_Invoke_m434D4F02FA25F91DF6199EC5A799C551C7F93702_OpenInst(PCMSetPositionCallback_t8D7135A2FB40647CAEC93F5254AD59E18DEB6072* __this, int32_t ___position0, const RuntimeMethod* method)
{
	typedef void (*FunctionPointerType) (int32_t, const RuntimeMethod*);
	((FunctionPointerType)__this->___method_ptr_0)(___position0, method);
}
void PCMSetPositionCallback_Invoke_m434D4F02FA25F91DF6199EC5A799C551C7F93702_OpenStatic(PCMSetPositionCallback_t8D7135A2FB40647CAEC93F5254AD59E18DEB6072* __this, int32_t ___position0, const RuntimeMethod* method)
{
	typedef void (*FunctionPointerType) (int32_t, const RuntimeMethod*);
	((FunctionPointerType)__this->___method_ptr_0)(___position0, method);
}
void PCMSetPositionCallback_Invoke_m434D4F02FA25F91DF6199EC5A799C551C7F93702_OpenStaticInvoker(PCMSetPositionCallback_t8D7135A2FB40647CAEC93F5254AD59E18DEB6072* __this, int32_t ___position0, const RuntimeMethod* method)
{
	InvokerActionInvoker1< int32_t >::Invoke(__this->___method_ptr_0, method, NULL, ___position0);
}
void PCMSetPositionCallback_Invoke_m434D4F02FA25F91DF6199EC5A799C551C7F93702_ClosedStaticInvoker(PCMSetPositionCallback_t8D7135A2FB40647CAEC93F5254AD59E18DEB6072* __this, int32_t ___position0, const RuntimeMethod* method)
{
	InvokerActionInvoker2< RuntimeObject*, int32_t >::Invoke(__this->___method_ptr_0, method, NULL, __this->___m_target_2, ___position0);
}
IL2CPP_EXTERN_C  void DelegatePInvokeWrapper_PCMSetPositionCallback_t8D7135A2FB40647CAEC93F5254AD59E18DEB6072 (PCMSetPositionCallback_t8D7135A2FB40647CAEC93F5254AD59E18DEB6072* __this, int32_t ___position0, const RuntimeMethod* method)
{
	typedef void (DEFAULT_CALL *PInvokeFunc)(int32_t);
	PInvokeFunc il2cppPInvokeFunc = reinterpret_cast<PInvokeFunc>(il2cpp_codegen_get_reverse_pinvoke_function_ptr(__this));
	// Native function invocation
	il2cppPInvokeFunc(___position0);

}
// System.Void UnityEngine.AudioClip/PCMSetPositionCallback::.ctor(System.Object,System.IntPtr)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void PCMSetPositionCallback__ctor_mD16F77DDB552EB69BB3F5EF39420B2F09F95455B (PCMSetPositionCallback_t8D7135A2FB40647CAEC93F5254AD59E18DEB6072* __this, RuntimeObject* ___object0, intptr_t ___method1, const RuntimeMethod* method) 
{
	__this->___method_ptr_0 = il2cpp_codegen_get_virtual_call_method_pointer((RuntimeMethod*)___method1);
	__this->___method_3 = ___method1;
	__this->___m_target_2 = ___object0;
	Il2CppCodeGenWriteBarrier((void**)(&__this->___m_target_2), (void*)___object0);
	int parameterCount = il2cpp_codegen_method_parameter_count((RuntimeMethod*)___method1);
	__this->___method_code_6 = (intptr_t)__this;
	if (MethodIsStatic((RuntimeMethod*)___method1))
	{
		bool isOpen = parameterCount == 1;
		if (il2cpp_codegen_call_method_via_invoker((RuntimeMethod*)___method1))
			if (isOpen)
				__this->___invoke_impl_1 = (intptr_t)&PCMSetPositionCallback_Invoke_m434D4F02FA25F91DF6199EC5A799C551C7F93702_OpenStaticInvoker;
			else
				__this->___invoke_impl_1 = (intptr_t)&PCMSetPositionCallback_Invoke_m434D4F02FA25F91DF6199EC5A799C551C7F93702_ClosedStaticInvoker;
		else
			if (isOpen)
				__this->___invoke_impl_1 = (intptr_t)&PCMSetPositionCallback_Invoke_m434D4F02FA25F91DF6199EC5A799C551C7F93702_OpenStatic;
			else
				{
					__this->___invoke_impl_1 = (intptr_t)__this->___method_ptr_0;
					__this->___method_code_6 = (intptr_t)__this->___m_target_2;
				}
	}
	else
	{
		if (___object0 == NULL)
			il2cpp_codegen_raise_exception(il2cpp_codegen_get_argument_exception(NULL, "Delegate to an instance method cannot have null 'this'."), NULL);
		__this->___invoke_impl_1 = (intptr_t)__this->___method_ptr_0;
		__this->___method_code_6 = (intptr_t)__this->___m_target_2;
	}
	__this->___extra_arg_5 = (intptr_t)&PCMSetPositionCallback_Invoke_m434D4F02FA25F91DF6199EC5A799C551C7F93702_Multicast;
}
// System.Void UnityEngine.AudioClip/PCMSetPositionCallback::Invoke(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void PCMSetPositionCallback_Invoke_m434D4F02FA25F91DF6199EC5A799C551C7F93702 (PCMSetPositionCallback_t8D7135A2FB40647CAEC93F5254AD59E18DEB6072* __this, int32_t ___position0, const RuntimeMethod* method) 
{
	typedef void (*FunctionPointerType) (RuntimeObject*, int32_t, const RuntimeMethod*);
	((FunctionPointerType)__this->___invoke_impl_1)((Il2CppObject*)__this->___method_code_6, ___position0, reinterpret_cast<RuntimeMethod*>(__this->___method_3));
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// UnityEngine.Audio.AudioClipPlayable UnityEngine.Audio.AudioClipPlayable::Create(UnityEngine.Playables.PlayableGraph,UnityEngine.AudioClip,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR AudioClipPlayable_tD4B758E68CAE03CB0CD31F90C8A3E603B97143A0 AudioClipPlayable_Create_mFDDE873B2BE8D1F691F19E91799DEB178A54BA0D (PlayableGraph_t4A5B0B45343A240F0761574FD7C672E0CFFF7A6E ___graph0, AudioClip_t5D272C4EB4F2D3ED49F1C346DEA373CF6D585F20* ___clip1, bool ___looping2, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AudioClipPlayable_Create_mFDDE873B2BE8D1F691F19E91799DEB178A54BA0D_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AudioClipPlayable_tD4B758E68CAE03CB0CD31F90C8A3E603B97143A0_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&PlayableExtensions_SetDuration_TisAudioClipPlayable_tD4B758E68CAE03CB0CD31F90C8A3E603B97143A0_m9A34D349E499987930B568EFE7C9A3F0B8AD47BC_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4_0_0_0_var);
		s_Il2CppMethodInitialized = true;
	}
	PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4 V_0;
	memset((&V_0), 0, sizeof(V_0));
	AudioClipPlayable_tD4B758E68CAE03CB0CD31F90C8A3E603B97143A0 V_1;
	memset((&V_1), 0, sizeof(V_1));
	bool V_2 = false;
	AudioClipPlayable_tD4B758E68CAE03CB0CD31F90C8A3E603B97143A0 V_3;
	memset((&V_3), 0, sizeof(V_3));
	DECLARE_METHOD_PARAMS(methodExecutionContextParameters, (&___graph0), (&___clip1), (&___looping2));
	DECLARE_METHOD_LOCALS(methodExecutionContextLocals, (&V_0), (&V_1));
	DECLARE_METHOD_EXEC_CTX(methodExecutionContext, AudioClipPlayable_Create_mFDDE873B2BE8D1F691F19E91799DEB178A54BA0D_RuntimeMethod_var, NULL, methodExecutionContextParameters, methodExecutionContextLocals);
	CHECK_METHOD_ENTRY_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 32));
	CHECK_METHOD_EXIT_SEQ_POINT(methodExitChecker, methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 33));
	{
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 34));
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 35));
		PlayableGraph_t4A5B0B45343A240F0761574FD7C672E0CFFF7A6E L_0 = ___graph0;
		AudioClip_t5D272C4EB4F2D3ED49F1C346DEA373CF6D585F20* L_1 = ___clip1;
		bool L_2 = ___looping2;
		STORE_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 36));
		PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4 L_3;
		L_3 = AudioClipPlayable_CreateHandle_m3D3EEAD0F584A14B608579167811E5B0497725D0(L_0, L_1, L_2, NULL);
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 36));
		V_0 = L_3;
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 37));
		PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4 L_4 = V_0;
		STORE_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 38));
		AudioClipPlayable__ctor_m4E686B92CFA7C6A36AA794B1E8C36B1E60605751((&V_1), L_4, NULL);
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 38));
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 39));
		AudioClip_t5D272C4EB4F2D3ED49F1C346DEA373CF6D585F20* L_5 = ___clip1;
		STORE_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 40));
		il2cpp_codegen_runtime_class_init_inline(Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		bool L_6;
		L_6 = Object_op_Inequality_m4D656395C27694A7F33F5AA8DE80A7AAF9E20BA7(L_5, (Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C*)NULL, NULL);
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 40));
		V_2 = L_6;
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 41));
		bool L_7 = V_2;
		if (!L_7)
		{
			goto IL_002b;
		}
	}
	{
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 42));
		AudioClipPlayable_tD4B758E68CAE03CB0CD31F90C8A3E603B97143A0 L_8 = V_1;
		AudioClip_t5D272C4EB4F2D3ED49F1C346DEA373CF6D585F20* L_9 = ___clip1;
		STORE_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 43));
		NullCheck(L_9);
		float L_10;
		L_10 = AudioClip_get_length_m6102CB29AF65988797452E4D6E43D4788303873D(L_9, NULL);
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 43));
		STORE_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 44));
		PlayableExtensions_SetDuration_TisAudioClipPlayable_tD4B758E68CAE03CB0CD31F90C8A3E603B97143A0_m9A34D349E499987930B568EFE7C9A3F0B8AD47BC(L_8, ((double)L_10), PlayableExtensions_SetDuration_TisAudioClipPlayable_tD4B758E68CAE03CB0CD31F90C8A3E603B97143A0_m9A34D349E499987930B568EFE7C9A3F0B8AD47BC_RuntimeMethod_var);
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 44));
	}

IL_002b:
	{
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 45));
		AudioClipPlayable_tD4B758E68CAE03CB0CD31F90C8A3E603B97143A0 L_11 = V_1;
		V_3 = L_11;
		goto IL_002f;
	}

IL_002f:
	{
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 46));
		AudioClipPlayable_tD4B758E68CAE03CB0CD31F90C8A3E603B97143A0 L_12 = V_3;
		return L_12;
	}
}
// UnityEngine.Playables.PlayableHandle UnityEngine.Audio.AudioClipPlayable::CreateHandle(UnityEngine.Playables.PlayableGraph,UnityEngine.AudioClip,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4 AudioClipPlayable_CreateHandle_m3D3EEAD0F584A14B608579167811E5B0497725D0 (PlayableGraph_t4A5B0B45343A240F0761574FD7C672E0CFFF7A6E ___graph0, AudioClip_t5D272C4EB4F2D3ED49F1C346DEA373CF6D585F20* ___clip1, bool ___looping2, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AudioClipPlayable_CreateHandle_m3D3EEAD0F584A14B608579167811E5B0497725D0_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4 V_0;
	memset((&V_0), 0, sizeof(V_0));
	bool V_1 = false;
	PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4 V_2;
	memset((&V_2), 0, sizeof(V_2));
	DECLARE_METHOD_PARAMS(methodExecutionContextParameters, (&___graph0), (&___clip1), (&___looping2));
	DECLARE_METHOD_LOCALS(methodExecutionContextLocals, (&V_0));
	DECLARE_METHOD_EXEC_CTX(methodExecutionContext, AudioClipPlayable_CreateHandle_m3D3EEAD0F584A14B608579167811E5B0497725D0_RuntimeMethod_var, NULL, methodExecutionContextParameters, methodExecutionContextLocals);
	CHECK_METHOD_ENTRY_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 47));
	CHECK_METHOD_EXIT_SEQ_POINT(methodExitChecker, methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 48));
	{
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 49));
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 50));
		STORE_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 51));
		il2cpp_codegen_runtime_class_init_inline(PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4_il2cpp_TypeInfo_var);
		PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4 L_0;
		L_0 = PlayableHandle_get_Null_m32D9E05C019AC0153C26392C7946F0A1654D1217(NULL);
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 51));
		V_0 = L_0;
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 52));
		AudioClip_t5D272C4EB4F2D3ED49F1C346DEA373CF6D585F20* L_1 = ___clip1;
		bool L_2 = ___looping2;
		STORE_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 53));
		bool L_3;
		L_3 = AudioClipPlayable_InternalCreateAudioClipPlayable_mB182B6257F637BFE9C0DAEA9656E747CB240AD2C((&___graph0), L_1, L_2, (&V_0), NULL);
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 53));
		V_1 = (bool)((((int32_t)L_3) == ((int32_t)0))? 1 : 0);
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 54));
		bool L_4 = V_1;
		if (!L_4)
		{
			goto IL_0021;
		}
	}
	{
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 55));
		STORE_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 56));
		il2cpp_codegen_runtime_class_init_inline(PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4_il2cpp_TypeInfo_var);
		PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4 L_5;
		L_5 = PlayableHandle_get_Null_m32D9E05C019AC0153C26392C7946F0A1654D1217(NULL);
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 56));
		V_2 = L_5;
		goto IL_0025;
	}

IL_0021:
	{
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 57));
		PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4 L_6 = V_0;
		V_2 = L_6;
		goto IL_0025;
	}

IL_0025:
	{
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 58));
		PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4 L_7 = V_2;
		return L_7;
	}
}
// System.Void UnityEngine.Audio.AudioClipPlayable::.ctor(UnityEngine.Playables.PlayableHandle)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AudioClipPlayable__ctor_m4E686B92CFA7C6A36AA794B1E8C36B1E60605751 (AudioClipPlayable_tD4B758E68CAE03CB0CD31F90C8A3E603B97143A0* __this, PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4 ___handle0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AudioClipPlayable__ctor_m4E686B92CFA7C6A36AA794B1E8C36B1E60605751_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AudioClipPlayable_tD4B758E68CAE03CB0CD31F90C8A3E603B97143A0_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&PlayableHandle_IsPlayableOfType_TisAudioClipPlayable_tD4B758E68CAE03CB0CD31F90C8A3E603B97143A0_m95809D16DD3494AEB0E9E652B42E0CE3167BEE0E_RuntimeMethod_var);
		s_Il2CppMethodInitialized = true;
	}
	bool V_0 = false;
	bool V_1 = false;
	DECLARE_METHOD_THIS(methodExecutionContextThis, (&__this));
	DECLARE_METHOD_PARAMS(methodExecutionContextParameters, (&___handle0));
	DECLARE_METHOD_EXEC_CTX(methodExecutionContext, AudioClipPlayable__ctor_m4E686B92CFA7C6A36AA794B1E8C36B1E60605751_RuntimeMethod_var, methodExecutionContextThis, methodExecutionContextParameters, NULL);
	CHECK_METHOD_ENTRY_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 59));
	CHECK_METHOD_EXIT_SEQ_POINT(methodExitChecker, methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 60));
	{
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 61));
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 62));
		STORE_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 63));
		bool L_0;
		L_0 = PlayableHandle_IsValid_m07631D12846BAAF2CC302E69A28A44BFE9EB5098((&___handle0), NULL);
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 63));
		V_0 = L_0;
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 64));
		bool L_1 = V_0;
		if (!L_1)
		{
			goto IL_0027;
		}
	}
	{
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 65));
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 66));
		STORE_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 67));
		bool L_2;
		L_2 = PlayableHandle_IsPlayableOfType_TisAudioClipPlayable_tD4B758E68CAE03CB0CD31F90C8A3E603B97143A0_m95809D16DD3494AEB0E9E652B42E0CE3167BEE0E((&___handle0), PlayableHandle_IsPlayableOfType_TisAudioClipPlayable_tD4B758E68CAE03CB0CD31F90C8A3E603B97143A0_m95809D16DD3494AEB0E9E652B42E0CE3167BEE0E_RuntimeMethod_var);
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 67));
		V_1 = (bool)((((int32_t)L_2) == ((int32_t)0))? 1 : 0);
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 68));
		bool L_3 = V_1;
		if (!L_3)
		{
			goto IL_0026;
		}
	}
	{
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 69));
		STORE_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 70));
		InvalidCastException_t47FC62F21A3937E814D20381DDACEF240E95AC2E* L_4 = (InvalidCastException_t47FC62F21A3937E814D20381DDACEF240E95AC2E*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&InvalidCastException_t47FC62F21A3937E814D20381DDACEF240E95AC2E_il2cpp_TypeInfo_var)));
		NullCheck(L_4);
		InvalidCastException__ctor_mED3F9781E6CA47A92C602C896EDDF2F40ECB8644(L_4, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteral57186E11345D0E246E80500DE17B8C941EF8A38F)), NULL);
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 70));
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_4, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&AudioClipPlayable__ctor_m4E686B92CFA7C6A36AA794B1E8C36B1E60605751_RuntimeMethod_var)));
	}

IL_0026:
	{
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 71));
	}

IL_0027:
	{
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 72));
		PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4 L_5 = ___handle0;
		__this->___m_Handle_0 = L_5;
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 73));
		return;
	}
}
IL2CPP_EXTERN_C  void AudioClipPlayable__ctor_m4E686B92CFA7C6A36AA794B1E8C36B1E60605751_AdjustorThunk (RuntimeObject* __this, PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4 ___handle0, const RuntimeMethod* method)
{
	AudioClipPlayable_tD4B758E68CAE03CB0CD31F90C8A3E603B97143A0* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<AudioClipPlayable_tD4B758E68CAE03CB0CD31F90C8A3E603B97143A0*>(__this + _offset);
	AudioClipPlayable__ctor_m4E686B92CFA7C6A36AA794B1E8C36B1E60605751(_thisAdjusted, ___handle0, method);
}
// UnityEngine.Playables.PlayableHandle UnityEngine.Audio.AudioClipPlayable::GetHandle()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4 AudioClipPlayable_GetHandle_mEA1D664328FF9B08E4F7D5EBCD4B51A754D97C44 (AudioClipPlayable_tD4B758E68CAE03CB0CD31F90C8A3E603B97143A0* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AudioClipPlayable_GetHandle_mEA1D664328FF9B08E4F7D5EBCD4B51A754D97C44_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AudioClipPlayable_tD4B758E68CAE03CB0CD31F90C8A3E603B97143A0_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4_0_0_0_var);
		s_Il2CppMethodInitialized = true;
	}
	PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4 V_0;
	memset((&V_0), 0, sizeof(V_0));
	DECLARE_METHOD_THIS(methodExecutionContextThis, (&__this));
	DECLARE_METHOD_EXEC_CTX(methodExecutionContext, AudioClipPlayable_GetHandle_mEA1D664328FF9B08E4F7D5EBCD4B51A754D97C44_RuntimeMethod_var, methodExecutionContextThis, NULL, NULL);
	CHECK_METHOD_ENTRY_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 74));
	CHECK_METHOD_EXIT_SEQ_POINT(methodExitChecker, methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 75));
	{
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 76));
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 77));
		PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4 L_0 = __this->___m_Handle_0;
		V_0 = L_0;
		goto IL_000a;
	}

IL_000a:
	{
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 78));
		PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4 L_1 = V_0;
		return L_1;
	}
}
IL2CPP_EXTERN_C  PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4 AudioClipPlayable_GetHandle_mEA1D664328FF9B08E4F7D5EBCD4B51A754D97C44_AdjustorThunk (RuntimeObject* __this, const RuntimeMethod* method)
{
	AudioClipPlayable_tD4B758E68CAE03CB0CD31F90C8A3E603B97143A0* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<AudioClipPlayable_tD4B758E68CAE03CB0CD31F90C8A3E603B97143A0*>(__this + _offset);
	PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4 _returnValue;
	_returnValue = AudioClipPlayable_GetHandle_mEA1D664328FF9B08E4F7D5EBCD4B51A754D97C44(_thisAdjusted, method);
	return _returnValue;
}
// UnityEngine.Playables.Playable UnityEngine.Audio.AudioClipPlayable::op_Implicit(UnityEngine.Audio.AudioClipPlayable)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Playable_t95C6B795846BA0C7D96E4DA14897CCCF2554334F AudioClipPlayable_op_Implicit_m22CDBB0717207ECCA3892A6281B565246EC2471B (AudioClipPlayable_tD4B758E68CAE03CB0CD31F90C8A3E603B97143A0 ___playable0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AudioClipPlayable_op_Implicit_m22CDBB0717207ECCA3892A6281B565246EC2471B_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Playable_t95C6B795846BA0C7D96E4DA14897CCCF2554334F_0_0_0_var);
		s_Il2CppMethodInitialized = true;
	}
	Playable_t95C6B795846BA0C7D96E4DA14897CCCF2554334F V_0;
	memset((&V_0), 0, sizeof(V_0));
	DECLARE_METHOD_PARAMS(methodExecutionContextParameters, (&___playable0));
	DECLARE_METHOD_EXEC_CTX(methodExecutionContext, AudioClipPlayable_op_Implicit_m22CDBB0717207ECCA3892A6281B565246EC2471B_RuntimeMethod_var, NULL, methodExecutionContextParameters, NULL);
	CHECK_METHOD_ENTRY_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 79));
	CHECK_METHOD_EXIT_SEQ_POINT(methodExitChecker, methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 80));
	{
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 81));
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 82));
		STORE_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 83));
		PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4 L_0;
		L_0 = AudioClipPlayable_GetHandle_mEA1D664328FF9B08E4F7D5EBCD4B51A754D97C44((&___playable0), NULL);
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 83));
		STORE_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 84));
		Playable_t95C6B795846BA0C7D96E4DA14897CCCF2554334F L_1;
		memset((&L_1), 0, sizeof(L_1));
		Playable__ctor_mD2EB35E024816AEED68795D0124EAB30E05BF6C4((&L_1), L_0, /*hidden argument*/NULL);
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 84));
		V_0 = L_1;
		goto IL_0010;
	}

IL_0010:
	{
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 85));
		Playable_t95C6B795846BA0C7D96E4DA14897CCCF2554334F L_2 = V_0;
		return L_2;
	}
}
// UnityEngine.Audio.AudioClipPlayable UnityEngine.Audio.AudioClipPlayable::op_Explicit(UnityEngine.Playables.Playable)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR AudioClipPlayable_tD4B758E68CAE03CB0CD31F90C8A3E603B97143A0 AudioClipPlayable_op_Explicit_m9A454352B526041DF081B09541EDA59E5190D7AB (Playable_t95C6B795846BA0C7D96E4DA14897CCCF2554334F ___playable0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AudioClipPlayable_op_Explicit_m9A454352B526041DF081B09541EDA59E5190D7AB_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AudioClipPlayable_tD4B758E68CAE03CB0CD31F90C8A3E603B97143A0_0_0_0_var);
		s_Il2CppMethodInitialized = true;
	}
	AudioClipPlayable_tD4B758E68CAE03CB0CD31F90C8A3E603B97143A0 V_0;
	memset((&V_0), 0, sizeof(V_0));
	DECLARE_METHOD_PARAMS(methodExecutionContextParameters, (&___playable0));
	DECLARE_METHOD_EXEC_CTX(methodExecutionContext, AudioClipPlayable_op_Explicit_m9A454352B526041DF081B09541EDA59E5190D7AB_RuntimeMethod_var, NULL, methodExecutionContextParameters, NULL);
	CHECK_METHOD_ENTRY_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 86));
	CHECK_METHOD_EXIT_SEQ_POINT(methodExitChecker, methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 87));
	{
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 88));
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 89));
		STORE_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 90));
		PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4 L_0;
		L_0 = Playable_GetHandle_m39356D23E849DC5428B262092657662C064E04F8((&___playable0), NULL);
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 90));
		STORE_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 91));
		AudioClipPlayable_tD4B758E68CAE03CB0CD31F90C8A3E603B97143A0 L_1;
		memset((&L_1), 0, sizeof(L_1));
		AudioClipPlayable__ctor_m4E686B92CFA7C6A36AA794B1E8C36B1E60605751((&L_1), L_0, /*hidden argument*/NULL);
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 91));
		V_0 = L_1;
		goto IL_0010;
	}

IL_0010:
	{
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 92));
		AudioClipPlayable_tD4B758E68CAE03CB0CD31F90C8A3E603B97143A0 L_2 = V_0;
		return L_2;
	}
}
// System.Boolean UnityEngine.Audio.AudioClipPlayable::Equals(UnityEngine.Audio.AudioClipPlayable)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool AudioClipPlayable_Equals_m9C1C75ACBB74FE06AD02BE4643F6EB39413EFF83 (AudioClipPlayable_tD4B758E68CAE03CB0CD31F90C8A3E603B97143A0* __this, AudioClipPlayable_tD4B758E68CAE03CB0CD31F90C8A3E603B97143A0 ___other0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AudioClipPlayable_Equals_m9C1C75ACBB74FE06AD02BE4643F6EB39413EFF83_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AudioClipPlayable_tD4B758E68CAE03CB0CD31F90C8A3E603B97143A0_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	bool V_0 = false;
	DECLARE_METHOD_THIS(methodExecutionContextThis, (&__this));
	DECLARE_METHOD_PARAMS(methodExecutionContextParameters, (&___other0));
	DECLARE_METHOD_EXEC_CTX(methodExecutionContext, AudioClipPlayable_Equals_m9C1C75ACBB74FE06AD02BE4643F6EB39413EFF83_RuntimeMethod_var, methodExecutionContextThis, methodExecutionContextParameters, NULL);
	CHECK_METHOD_ENTRY_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 93));
	CHECK_METHOD_EXIT_SEQ_POINT(methodExitChecker, methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 94));
	{
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 95));
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 96));
		STORE_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 97));
		PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4 L_0;
		L_0 = AudioClipPlayable_GetHandle_mEA1D664328FF9B08E4F7D5EBCD4B51A754D97C44(__this, NULL);
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 97));
		STORE_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 98));
		PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4 L_1;
		L_1 = AudioClipPlayable_GetHandle_mEA1D664328FF9B08E4F7D5EBCD4B51A754D97C44((&___other0), NULL);
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 98));
		STORE_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 99));
		il2cpp_codegen_runtime_class_init_inline(PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4_il2cpp_TypeInfo_var);
		bool L_2;
		L_2 = PlayableHandle_op_Equality_m5E9B847A9D36875C78902727FE36FBEDA4D2D3B9(L_0, L_1, NULL);
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 99));
		V_0 = L_2;
		goto IL_0016;
	}

IL_0016:
	{
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 100));
		bool L_3 = V_0;
		return L_3;
	}
}
IL2CPP_EXTERN_C  bool AudioClipPlayable_Equals_m9C1C75ACBB74FE06AD02BE4643F6EB39413EFF83_AdjustorThunk (RuntimeObject* __this, AudioClipPlayable_tD4B758E68CAE03CB0CD31F90C8A3E603B97143A0 ___other0, const RuntimeMethod* method)
{
	AudioClipPlayable_tD4B758E68CAE03CB0CD31F90C8A3E603B97143A0* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<AudioClipPlayable_tD4B758E68CAE03CB0CD31F90C8A3E603B97143A0*>(__this + _offset);
	bool _returnValue;
	_returnValue = AudioClipPlayable_Equals_m9C1C75ACBB74FE06AD02BE4643F6EB39413EFF83(_thisAdjusted, ___other0, method);
	return _returnValue;
}
// System.Void UnityEngine.Audio.AudioClipPlayable::SetVolume(System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AudioClipPlayable_SetVolume_m3553EC43CBA43CA7802292710A1A284A6DEF8FCC (AudioClipPlayable_tD4B758E68CAE03CB0CD31F90C8A3E603B97143A0* __this, float ___value0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AudioClipPlayable_SetVolume_m3553EC43CBA43CA7802292710A1A284A6DEF8FCC_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AudioClipPlayable_tD4B758E68CAE03CB0CD31F90C8A3E603B97143A0_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_0_0_0_var);
		s_Il2CppMethodInitialized = true;
	}
	bool V_0 = false;
	DECLARE_METHOD_THIS(methodExecutionContextThis, (&__this));
	DECLARE_METHOD_PARAMS(methodExecutionContextParameters, (&___value0));
	DECLARE_METHOD_EXEC_CTX(methodExecutionContext, AudioClipPlayable_SetVolume_m3553EC43CBA43CA7802292710A1A284A6DEF8FCC_RuntimeMethod_var, methodExecutionContextThis, methodExecutionContextParameters, NULL);
	CHECK_METHOD_ENTRY_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 101));
	CHECK_METHOD_EXIT_SEQ_POINT(methodExitChecker, methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 102));
	int32_t G_B3_0 = 0;
	{
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 103));
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 104));
		float L_0 = ___value0;
		if ((((float)L_0) < ((float)(0.0f))))
		{
			goto IL_0013;
		}
	}
	{
		float L_1 = ___value0;
		G_B3_0 = ((((float)L_1) > ((float)(1.0f)))? 1 : 0);
		goto IL_0014;
	}

IL_0013:
	{
		G_B3_0 = 1;
	}

IL_0014:
	{
		V_0 = (bool)G_B3_0;
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 105));
		bool L_2 = V_0;
		if (!L_2)
		{
			goto IL_002f;
		}
	}
	{
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 106));
		STORE_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 107));
		String_t* L_3;
		L_3 = Single_ToString_mE282EDA9CA4F7DF88432D807732837A629D04972((&___value0), NULL);
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 107));
		STORE_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 108));
		String_t* L_4;
		L_4 = String_Concat_mAF2CE02CC0CB7460753D0A1A91CCF2B1E9804C5D(((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteral0574E31B2E15797E57C51DEC554AE14E00CCB9CC)), L_3, NULL);
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 108));
		STORE_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 109));
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_5 = (ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)));
		NullCheck(L_5);
		ArgumentException__ctor_m026938A67AF9D36BB7ED27F80425D7194B514465(L_5, L_4, NULL);
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 109));
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_5, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&AudioClipPlayable_SetVolume_m3553EC43CBA43CA7802292710A1A284A6DEF8FCC_RuntimeMethod_var)));
	}

IL_002f:
	{
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 110));
		PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4* L_6 = (&__this->___m_Handle_0);
		float L_7 = ___value0;
		STORE_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 111));
		AudioClipPlayable_SetVolumeInternal_mA0A7BCFDD9F1E0761AEFD71C2EA0CBD96B7B069B(L_6, L_7, NULL);
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 111));
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 112));
		return;
	}
}
IL2CPP_EXTERN_C  void AudioClipPlayable_SetVolume_m3553EC43CBA43CA7802292710A1A284A6DEF8FCC_AdjustorThunk (RuntimeObject* __this, float ___value0, const RuntimeMethod* method)
{
	AudioClipPlayable_tD4B758E68CAE03CB0CD31F90C8A3E603B97143A0* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<AudioClipPlayable_tD4B758E68CAE03CB0CD31F90C8A3E603B97143A0*>(__this + _offset);
	AudioClipPlayable_SetVolume_m3553EC43CBA43CA7802292710A1A284A6DEF8FCC(_thisAdjusted, ___value0, method);
}
// System.Void UnityEngine.Audio.AudioClipPlayable::SetStereoPan(System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AudioClipPlayable_SetStereoPan_mB8403E93B06B2ECCD0D4D6B0D55C151D0CCCC494 (AudioClipPlayable_tD4B758E68CAE03CB0CD31F90C8A3E603B97143A0* __this, float ___value0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AudioClipPlayable_SetStereoPan_mB8403E93B06B2ECCD0D4D6B0D55C151D0CCCC494_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AudioClipPlayable_tD4B758E68CAE03CB0CD31F90C8A3E603B97143A0_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_0_0_0_var);
		s_Il2CppMethodInitialized = true;
	}
	bool V_0 = false;
	DECLARE_METHOD_THIS(methodExecutionContextThis, (&__this));
	DECLARE_METHOD_PARAMS(methodExecutionContextParameters, (&___value0));
	DECLARE_METHOD_EXEC_CTX(methodExecutionContext, AudioClipPlayable_SetStereoPan_mB8403E93B06B2ECCD0D4D6B0D55C151D0CCCC494_RuntimeMethod_var, methodExecutionContextThis, methodExecutionContextParameters, NULL);
	CHECK_METHOD_ENTRY_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 113));
	CHECK_METHOD_EXIT_SEQ_POINT(methodExitChecker, methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 114));
	int32_t G_B3_0 = 0;
	{
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 115));
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 116));
		float L_0 = ___value0;
		if ((((float)L_0) < ((float)(-1.0f))))
		{
			goto IL_0013;
		}
	}
	{
		float L_1 = ___value0;
		G_B3_0 = ((((float)L_1) > ((float)(1.0f)))? 1 : 0);
		goto IL_0014;
	}

IL_0013:
	{
		G_B3_0 = 1;
	}

IL_0014:
	{
		V_0 = (bool)G_B3_0;
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 117));
		bool L_2 = V_0;
		if (!L_2)
		{
			goto IL_002f;
		}
	}
	{
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 118));
		STORE_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 119));
		String_t* L_3;
		L_3 = Single_ToString_mE282EDA9CA4F7DF88432D807732837A629D04972((&___value0), NULL);
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 119));
		STORE_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 120));
		String_t* L_4;
		L_4 = String_Concat_mAF2CE02CC0CB7460753D0A1A91CCF2B1E9804C5D(((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteral0FC2A6DFBAD242B7CE1A74ACA9D3224CE2E0163D)), L_3, NULL);
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 120));
		STORE_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 121));
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_5 = (ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)));
		NullCheck(L_5);
		ArgumentException__ctor_m026938A67AF9D36BB7ED27F80425D7194B514465(L_5, L_4, NULL);
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 121));
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_5, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&AudioClipPlayable_SetStereoPan_mB8403E93B06B2ECCD0D4D6B0D55C151D0CCCC494_RuntimeMethod_var)));
	}

IL_002f:
	{
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 122));
		PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4* L_6 = (&__this->___m_Handle_0);
		float L_7 = ___value0;
		STORE_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 123));
		AudioClipPlayable_SetStereoPanInternal_m948B61F4B67962F30C758AF034C6485A38EE5E53(L_6, L_7, NULL);
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 123));
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 124));
		return;
	}
}
IL2CPP_EXTERN_C  void AudioClipPlayable_SetStereoPan_mB8403E93B06B2ECCD0D4D6B0D55C151D0CCCC494_AdjustorThunk (RuntimeObject* __this, float ___value0, const RuntimeMethod* method)
{
	AudioClipPlayable_tD4B758E68CAE03CB0CD31F90C8A3E603B97143A0* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<AudioClipPlayable_tD4B758E68CAE03CB0CD31F90C8A3E603B97143A0*>(__this + _offset);
	AudioClipPlayable_SetStereoPan_mB8403E93B06B2ECCD0D4D6B0D55C151D0CCCC494(_thisAdjusted, ___value0, method);
}
// System.Void UnityEngine.Audio.AudioClipPlayable::SetSpatialBlend(System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AudioClipPlayable_SetSpatialBlend_m72F1B86E4E5940E8587C1EA32BB48463A00810BB (AudioClipPlayable_tD4B758E68CAE03CB0CD31F90C8A3E603B97143A0* __this, float ___value0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AudioClipPlayable_SetSpatialBlend_m72F1B86E4E5940E8587C1EA32BB48463A00810BB_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AudioClipPlayable_tD4B758E68CAE03CB0CD31F90C8A3E603B97143A0_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_0_0_0_var);
		s_Il2CppMethodInitialized = true;
	}
	bool V_0 = false;
	DECLARE_METHOD_THIS(methodExecutionContextThis, (&__this));
	DECLARE_METHOD_PARAMS(methodExecutionContextParameters, (&___value0));
	DECLARE_METHOD_EXEC_CTX(methodExecutionContext, AudioClipPlayable_SetSpatialBlend_m72F1B86E4E5940E8587C1EA32BB48463A00810BB_RuntimeMethod_var, methodExecutionContextThis, methodExecutionContextParameters, NULL);
	CHECK_METHOD_ENTRY_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 125));
	CHECK_METHOD_EXIT_SEQ_POINT(methodExitChecker, methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 126));
	int32_t G_B3_0 = 0;
	{
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 127));
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 128));
		float L_0 = ___value0;
		if ((((float)L_0) < ((float)(0.0f))))
		{
			goto IL_0013;
		}
	}
	{
		float L_1 = ___value0;
		G_B3_0 = ((((float)L_1) > ((float)(1.0f)))? 1 : 0);
		goto IL_0014;
	}

IL_0013:
	{
		G_B3_0 = 1;
	}

IL_0014:
	{
		V_0 = (bool)G_B3_0;
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 129));
		bool L_2 = V_0;
		if (!L_2)
		{
			goto IL_002f;
		}
	}
	{
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 130));
		STORE_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 131));
		String_t* L_3;
		L_3 = Single_ToString_mE282EDA9CA4F7DF88432D807732837A629D04972((&___value0), NULL);
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 131));
		STORE_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 132));
		String_t* L_4;
		L_4 = String_Concat_mAF2CE02CC0CB7460753D0A1A91CCF2B1E9804C5D(((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteral706336A4F6F53F903F6BD416474754F528D2A13B)), L_3, NULL);
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 132));
		STORE_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 133));
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_5 = (ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)));
		NullCheck(L_5);
		ArgumentException__ctor_m026938A67AF9D36BB7ED27F80425D7194B514465(L_5, L_4, NULL);
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 133));
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_5, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&AudioClipPlayable_SetSpatialBlend_m72F1B86E4E5940E8587C1EA32BB48463A00810BB_RuntimeMethod_var)));
	}

IL_002f:
	{
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 134));
		PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4* L_6 = (&__this->___m_Handle_0);
		float L_7 = ___value0;
		STORE_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 135));
		AudioClipPlayable_SetSpatialBlendInternal_m7BEEE6E7D5C276BD591F7103777610CFAFDE364F(L_6, L_7, NULL);
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 135));
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 136));
		return;
	}
}
IL2CPP_EXTERN_C  void AudioClipPlayable_SetSpatialBlend_m72F1B86E4E5940E8587C1EA32BB48463A00810BB_AdjustorThunk (RuntimeObject* __this, float ___value0, const RuntimeMethod* method)
{
	AudioClipPlayable_tD4B758E68CAE03CB0CD31F90C8A3E603B97143A0* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<AudioClipPlayable_tD4B758E68CAE03CB0CD31F90C8A3E603B97143A0*>(__this + _offset);
	AudioClipPlayable_SetSpatialBlend_m72F1B86E4E5940E8587C1EA32BB48463A00810BB(_thisAdjusted, ___value0, method);
}
// System.Void UnityEngine.Audio.AudioClipPlayable::Seek(System.Double,System.Double,System.Double)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AudioClipPlayable_Seek_m2AB327B535C677793BBADEA634B7AAC9442B1391 (AudioClipPlayable_tD4B758E68CAE03CB0CD31F90C8A3E603B97143A0* __this, double ___startTime0, double ___startDelay1, double ___duration2, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AudioClipPlayable_Seek_m2AB327B535C677793BBADEA634B7AAC9442B1391_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AudioClipPlayable_tD4B758E68CAE03CB0CD31F90C8A3E603B97143A0_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_0_0_0_var);
		s_Il2CppMethodInitialized = true;
	}
	bool V_0 = false;
	DECLARE_METHOD_THIS(methodExecutionContextThis, (&__this));
	DECLARE_METHOD_PARAMS(methodExecutionContextParameters, (&___startTime0), (&___startDelay1), (&___duration2));
	DECLARE_METHOD_EXEC_CTX(methodExecutionContext, AudioClipPlayable_Seek_m2AB327B535C677793BBADEA634B7AAC9442B1391_RuntimeMethod_var, methodExecutionContextThis, methodExecutionContextParameters, NULL);
	CHECK_METHOD_ENTRY_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 137));
	CHECK_METHOD_EXIT_SEQ_POINT(methodExitChecker, methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 138));
	{
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 139));
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 140));
		PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4* L_0 = (&__this->___m_Handle_0);
		double L_1 = ___startDelay1;
		STORE_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 141));
		AudioClipPlayable_SetStartDelayInternal_mC4222F4234A7414E77D08E4E9E1CF25990FF38F5(L_0, L_1, NULL);
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 141));
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 142));
		double L_2 = ___duration2;
		V_0 = (bool)((((double)L_2) > ((double)(0.0)))? 1 : 0);
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 143));
		bool L_3 = V_0;
		if (!L_3)
		{
			goto IL_0040;
		}
	}
	{
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 144));
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 145));
		PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4* L_4 = (&__this->___m_Handle_0);
		double L_5 = ___duration2;
		double L_6 = ___startTime0;
		STORE_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 146));
		PlayableHandle_SetDuration_m4E07F9F3A90B2F3CE10325D9F405993F03CCA08B(L_4, ((double)il2cpp_codegen_add(L_5, L_6)), NULL);
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 146));
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 147));
		PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4* L_7 = (&__this->___m_Handle_0);
		double L_8 = ___startDelay1;
		double L_9 = ___duration2;
		STORE_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 148));
		AudioClipPlayable_SetPauseDelayInternal_m58071C3C9A03DEB0B4D9F3D43367CE1F0F11AB32(L_7, ((double)il2cpp_codegen_add(L_8, L_9)), NULL);
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 148));
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 149));
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 150));
		goto IL_006c;
	}

IL_0040:
	{
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 151));
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 152));
		PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4* L_10 = (&__this->___m_Handle_0);
		STORE_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 153));
		PlayableHandle_SetDuration_m4E07F9F3A90B2F3CE10325D9F405993F03CCA08B(L_10, (1.7976931348623157E+308), NULL);
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 153));
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 154));
		PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4* L_11 = (&__this->___m_Handle_0);
		STORE_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 155));
		AudioClipPlayable_SetPauseDelayInternal_m58071C3C9A03DEB0B4D9F3D43367CE1F0F11AB32(L_11, (0.0), NULL);
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 155));
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 156));
	}

IL_006c:
	{
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 157));
		PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4* L_12 = (&__this->___m_Handle_0);
		double L_13 = ___startTime0;
		STORE_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 158));
		PlayableHandle_SetTime_m6D255AB6779F3DC278813F1C016FE4EBC9F4B1E4(L_12, L_13, NULL);
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 158));
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 159));
		PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4* L_14 = (&__this->___m_Handle_0);
		STORE_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 160));
		PlayableHandle_Play_m1EF8E1105EB6A4A9B0D6638A57CDCBCEEDC6FB2D(L_14, NULL);
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 160));
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 161));
		return;
	}
}
IL2CPP_EXTERN_C  void AudioClipPlayable_Seek_m2AB327B535C677793BBADEA634B7AAC9442B1391_AdjustorThunk (RuntimeObject* __this, double ___startTime0, double ___startDelay1, double ___duration2, const RuntimeMethod* method)
{
	AudioClipPlayable_tD4B758E68CAE03CB0CD31F90C8A3E603B97143A0* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<AudioClipPlayable_tD4B758E68CAE03CB0CD31F90C8A3E603B97143A0*>(__this + _offset);
	AudioClipPlayable_Seek_m2AB327B535C677793BBADEA634B7AAC9442B1391(_thisAdjusted, ___startTime0, ___startDelay1, ___duration2, method);
}
// System.Void UnityEngine.Audio.AudioClipPlayable::SetVolumeInternal(UnityEngine.Playables.PlayableHandle&,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AudioClipPlayable_SetVolumeInternal_mA0A7BCFDD9F1E0761AEFD71C2EA0CBD96B7B069B (PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4* ___hdl0, float ___volume1, const RuntimeMethod* method) 
{
	typedef void (*AudioClipPlayable_SetVolumeInternal_mA0A7BCFDD9F1E0761AEFD71C2EA0CBD96B7B069B_ftn) (PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4*, float);
	static AudioClipPlayable_SetVolumeInternal_mA0A7BCFDD9F1E0761AEFD71C2EA0CBD96B7B069B_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (AudioClipPlayable_SetVolumeInternal_mA0A7BCFDD9F1E0761AEFD71C2EA0CBD96B7B069B_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Audio.AudioClipPlayable::SetVolumeInternal(UnityEngine.Playables.PlayableHandle&,System.Single)");
	_il2cpp_icall_func(___hdl0, ___volume1);
}
// System.Void UnityEngine.Audio.AudioClipPlayable::SetStereoPanInternal(UnityEngine.Playables.PlayableHandle&,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AudioClipPlayable_SetStereoPanInternal_m948B61F4B67962F30C758AF034C6485A38EE5E53 (PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4* ___hdl0, float ___stereoPan1, const RuntimeMethod* method) 
{
	typedef void (*AudioClipPlayable_SetStereoPanInternal_m948B61F4B67962F30C758AF034C6485A38EE5E53_ftn) (PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4*, float);
	static AudioClipPlayable_SetStereoPanInternal_m948B61F4B67962F30C758AF034C6485A38EE5E53_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (AudioClipPlayable_SetStereoPanInternal_m948B61F4B67962F30C758AF034C6485A38EE5E53_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Audio.AudioClipPlayable::SetStereoPanInternal(UnityEngine.Playables.PlayableHandle&,System.Single)");
	_il2cpp_icall_func(___hdl0, ___stereoPan1);
}
// System.Void UnityEngine.Audio.AudioClipPlayable::SetSpatialBlendInternal(UnityEngine.Playables.PlayableHandle&,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AudioClipPlayable_SetSpatialBlendInternal_m7BEEE6E7D5C276BD591F7103777610CFAFDE364F (PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4* ___hdl0, float ___spatialBlend1, const RuntimeMethod* method) 
{
	typedef void (*AudioClipPlayable_SetSpatialBlendInternal_m7BEEE6E7D5C276BD591F7103777610CFAFDE364F_ftn) (PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4*, float);
	static AudioClipPlayable_SetSpatialBlendInternal_m7BEEE6E7D5C276BD591F7103777610CFAFDE364F_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (AudioClipPlayable_SetSpatialBlendInternal_m7BEEE6E7D5C276BD591F7103777610CFAFDE364F_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Audio.AudioClipPlayable::SetSpatialBlendInternal(UnityEngine.Playables.PlayableHandle&,System.Single)");
	_il2cpp_icall_func(___hdl0, ___spatialBlend1);
}
// System.Void UnityEngine.Audio.AudioClipPlayable::SetStartDelayInternal(UnityEngine.Playables.PlayableHandle&,System.Double)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AudioClipPlayable_SetStartDelayInternal_mC4222F4234A7414E77D08E4E9E1CF25990FF38F5 (PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4* ___hdl0, double ___delay1, const RuntimeMethod* method) 
{
	typedef void (*AudioClipPlayable_SetStartDelayInternal_mC4222F4234A7414E77D08E4E9E1CF25990FF38F5_ftn) (PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4*, double);
	static AudioClipPlayable_SetStartDelayInternal_mC4222F4234A7414E77D08E4E9E1CF25990FF38F5_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (AudioClipPlayable_SetStartDelayInternal_mC4222F4234A7414E77D08E4E9E1CF25990FF38F5_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Audio.AudioClipPlayable::SetStartDelayInternal(UnityEngine.Playables.PlayableHandle&,System.Double)");
	_il2cpp_icall_func(___hdl0, ___delay1);
}
// System.Void UnityEngine.Audio.AudioClipPlayable::SetPauseDelayInternal(UnityEngine.Playables.PlayableHandle&,System.Double)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AudioClipPlayable_SetPauseDelayInternal_m58071C3C9A03DEB0B4D9F3D43367CE1F0F11AB32 (PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4* ___hdl0, double ___delay1, const RuntimeMethod* method) 
{
	typedef void (*AudioClipPlayable_SetPauseDelayInternal_m58071C3C9A03DEB0B4D9F3D43367CE1F0F11AB32_ftn) (PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4*, double);
	static AudioClipPlayable_SetPauseDelayInternal_m58071C3C9A03DEB0B4D9F3D43367CE1F0F11AB32_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (AudioClipPlayable_SetPauseDelayInternal_m58071C3C9A03DEB0B4D9F3D43367CE1F0F11AB32_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Audio.AudioClipPlayable::SetPauseDelayInternal(UnityEngine.Playables.PlayableHandle&,System.Double)");
	_il2cpp_icall_func(___hdl0, ___delay1);
}
// System.Boolean UnityEngine.Audio.AudioClipPlayable::InternalCreateAudioClipPlayable(UnityEngine.Playables.PlayableGraph&,UnityEngine.AudioClip,System.Boolean,UnityEngine.Playables.PlayableHandle&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool AudioClipPlayable_InternalCreateAudioClipPlayable_mB182B6257F637BFE9C0DAEA9656E747CB240AD2C (PlayableGraph_t4A5B0B45343A240F0761574FD7C672E0CFFF7A6E* ___graph0, AudioClip_t5D272C4EB4F2D3ED49F1C346DEA373CF6D585F20* ___clip1, bool ___looping2, PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4* ___handle3, const RuntimeMethod* method) 
{
	typedef bool (*AudioClipPlayable_InternalCreateAudioClipPlayable_mB182B6257F637BFE9C0DAEA9656E747CB240AD2C_ftn) (PlayableGraph_t4A5B0B45343A240F0761574FD7C672E0CFFF7A6E*, AudioClip_t5D272C4EB4F2D3ED49F1C346DEA373CF6D585F20*, bool, PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4*);
	static AudioClipPlayable_InternalCreateAudioClipPlayable_mB182B6257F637BFE9C0DAEA9656E747CB240AD2C_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (AudioClipPlayable_InternalCreateAudioClipPlayable_mB182B6257F637BFE9C0DAEA9656E747CB240AD2C_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Audio.AudioClipPlayable::InternalCreateAudioClipPlayable(UnityEngine.Playables.PlayableGraph&,UnityEngine.AudioClip,System.Boolean,UnityEngine.Playables.PlayableHandle&)");
	bool icallRetVal = _il2cpp_icall_func(___graph0, ___clip1, ___looping2, ___handle3);
	return icallRetVal;
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// UnityEngine.Audio.AudioMixerPlayable UnityEngine.Audio.AudioMixerPlayable::Create(UnityEngine.Playables.PlayableGraph,System.Int32,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR AudioMixerPlayable_t6AADDF0C53DF1B4C17969EC24B3B4E4975F3A56C AudioMixerPlayable_Create_m026262C8CC01A49EF65B12B37ADD386D7666C230 (PlayableGraph_t4A5B0B45343A240F0761574FD7C672E0CFFF7A6E ___graph0, int32_t ___inputCount1, bool ___normalizeInputVolumes2, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AudioMixerPlayable_Create_m026262C8CC01A49EF65B12B37ADD386D7666C230_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AudioMixerPlayable_t6AADDF0C53DF1B4C17969EC24B3B4E4975F3A56C_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4_0_0_0_var);
		s_Il2CppMethodInitialized = true;
	}
	PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4 V_0;
	memset((&V_0), 0, sizeof(V_0));
	AudioMixerPlayable_t6AADDF0C53DF1B4C17969EC24B3B4E4975F3A56C V_1;
	memset((&V_1), 0, sizeof(V_1));
	DECLARE_METHOD_PARAMS(methodExecutionContextParameters, (&___graph0), (&___inputCount1), (&___normalizeInputVolumes2));
	DECLARE_METHOD_LOCALS(methodExecutionContextLocals, (&V_0));
	DECLARE_METHOD_EXEC_CTX(methodExecutionContext, AudioMixerPlayable_Create_m026262C8CC01A49EF65B12B37ADD386D7666C230_RuntimeMethod_var, NULL, methodExecutionContextParameters, methodExecutionContextLocals);
	CHECK_METHOD_ENTRY_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 162));
	CHECK_METHOD_EXIT_SEQ_POINT(methodExitChecker, methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 163));
	{
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 164));
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 165));
		PlayableGraph_t4A5B0B45343A240F0761574FD7C672E0CFFF7A6E L_0 = ___graph0;
		int32_t L_1 = ___inputCount1;
		bool L_2 = ___normalizeInputVolumes2;
		STORE_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 166));
		PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4 L_3;
		L_3 = AudioMixerPlayable_CreateHandle_m8D8F9B1AD8C50F1B441F403E16FFCFF60449CBD4(L_0, L_1, L_2, NULL);
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 166));
		V_0 = L_3;
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 167));
		PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4 L_4 = V_0;
		STORE_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 168));
		AudioMixerPlayable_t6AADDF0C53DF1B4C17969EC24B3B4E4975F3A56C L_5;
		memset((&L_5), 0, sizeof(L_5));
		AudioMixerPlayable__ctor_m2CDDE33FCE0B3F7D9EB482D76515FBF771285F47((&L_5), L_4, /*hidden argument*/NULL);
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 168));
		V_1 = L_5;
		goto IL_0013;
	}

IL_0013:
	{
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 169));
		AudioMixerPlayable_t6AADDF0C53DF1B4C17969EC24B3B4E4975F3A56C L_6 = V_1;
		return L_6;
	}
}
// UnityEngine.Playables.PlayableHandle UnityEngine.Audio.AudioMixerPlayable::CreateHandle(UnityEngine.Playables.PlayableGraph,System.Int32,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4 AudioMixerPlayable_CreateHandle_m8D8F9B1AD8C50F1B441F403E16FFCFF60449CBD4 (PlayableGraph_t4A5B0B45343A240F0761574FD7C672E0CFFF7A6E ___graph0, int32_t ___inputCount1, bool ___normalizeInputVolumes2, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AudioMixerPlayable_CreateHandle_m8D8F9B1AD8C50F1B441F403E16FFCFF60449CBD4_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4 V_0;
	memset((&V_0), 0, sizeof(V_0));
	bool V_1 = false;
	PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4 V_2;
	memset((&V_2), 0, sizeof(V_2));
	DECLARE_METHOD_PARAMS(methodExecutionContextParameters, (&___graph0), (&___inputCount1), (&___normalizeInputVolumes2));
	DECLARE_METHOD_LOCALS(methodExecutionContextLocals, (&V_0));
	DECLARE_METHOD_EXEC_CTX(methodExecutionContext, AudioMixerPlayable_CreateHandle_m8D8F9B1AD8C50F1B441F403E16FFCFF60449CBD4_RuntimeMethod_var, NULL, methodExecutionContextParameters, methodExecutionContextLocals);
	CHECK_METHOD_ENTRY_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 170));
	CHECK_METHOD_EXIT_SEQ_POINT(methodExitChecker, methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 171));
	{
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 172));
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 173));
		STORE_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 174));
		il2cpp_codegen_runtime_class_init_inline(PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4_il2cpp_TypeInfo_var);
		PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4 L_0;
		L_0 = PlayableHandle_get_Null_m32D9E05C019AC0153C26392C7946F0A1654D1217(NULL);
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 174));
		V_0 = L_0;
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 175));
		bool L_1 = ___normalizeInputVolumes2;
		STORE_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 176));
		bool L_2;
		L_2 = AudioMixerPlayable_CreateAudioMixerPlayableInternal_m7DABB246E18952B463177F30CF4BF3933FF1C14B((&___graph0), L_1, (&V_0), NULL);
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 176));
		V_1 = (bool)((((int32_t)L_2) == ((int32_t)0))? 1 : 0);
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 177));
		bool L_3 = V_1;
		if (!L_3)
		{
			goto IL_0020;
		}
	}
	{
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 178));
		STORE_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 179));
		il2cpp_codegen_runtime_class_init_inline(PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4_il2cpp_TypeInfo_var);
		PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4 L_4;
		L_4 = PlayableHandle_get_Null_m32D9E05C019AC0153C26392C7946F0A1654D1217(NULL);
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 179));
		V_2 = L_4;
		goto IL_002d;
	}

IL_0020:
	{
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 180));
		int32_t L_5 = ___inputCount1;
		STORE_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 181));
		PlayableHandle_SetInputCount_m6067CD3616C428F777903FCBFD789060A2185DEE((&V_0), L_5, NULL);
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 181));
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 182));
		PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4 L_6 = V_0;
		V_2 = L_6;
		goto IL_002d;
	}

IL_002d:
	{
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 183));
		PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4 L_7 = V_2;
		return L_7;
	}
}
// System.Void UnityEngine.Audio.AudioMixerPlayable::.ctor(UnityEngine.Playables.PlayableHandle)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AudioMixerPlayable__ctor_m2CDDE33FCE0B3F7D9EB482D76515FBF771285F47 (AudioMixerPlayable_t6AADDF0C53DF1B4C17969EC24B3B4E4975F3A56C* __this, PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4 ___handle0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AudioMixerPlayable__ctor_m2CDDE33FCE0B3F7D9EB482D76515FBF771285F47_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AudioMixerPlayable_t6AADDF0C53DF1B4C17969EC24B3B4E4975F3A56C_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&PlayableHandle_IsPlayableOfType_TisAudioMixerPlayable_t6AADDF0C53DF1B4C17969EC24B3B4E4975F3A56C_m28F89BE3D7CCE69B28258CC5B1C7D4E814F48CAB_RuntimeMethod_var);
		s_Il2CppMethodInitialized = true;
	}
	bool V_0 = false;
	bool V_1 = false;
	DECLARE_METHOD_THIS(methodExecutionContextThis, (&__this));
	DECLARE_METHOD_PARAMS(methodExecutionContextParameters, (&___handle0));
	DECLARE_METHOD_EXEC_CTX(methodExecutionContext, AudioMixerPlayable__ctor_m2CDDE33FCE0B3F7D9EB482D76515FBF771285F47_RuntimeMethod_var, methodExecutionContextThis, methodExecutionContextParameters, NULL);
	CHECK_METHOD_ENTRY_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 184));
	CHECK_METHOD_EXIT_SEQ_POINT(methodExitChecker, methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 185));
	{
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 186));
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 187));
		STORE_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 188));
		bool L_0;
		L_0 = PlayableHandle_IsValid_m07631D12846BAAF2CC302E69A28A44BFE9EB5098((&___handle0), NULL);
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 188));
		V_0 = L_0;
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 189));
		bool L_1 = V_0;
		if (!L_1)
		{
			goto IL_0027;
		}
	}
	{
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 190));
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 191));
		STORE_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 192));
		bool L_2;
		L_2 = PlayableHandle_IsPlayableOfType_TisAudioMixerPlayable_t6AADDF0C53DF1B4C17969EC24B3B4E4975F3A56C_m28F89BE3D7CCE69B28258CC5B1C7D4E814F48CAB((&___handle0), PlayableHandle_IsPlayableOfType_TisAudioMixerPlayable_t6AADDF0C53DF1B4C17969EC24B3B4E4975F3A56C_m28F89BE3D7CCE69B28258CC5B1C7D4E814F48CAB_RuntimeMethod_var);
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 192));
		V_1 = (bool)((((int32_t)L_2) == ((int32_t)0))? 1 : 0);
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 193));
		bool L_3 = V_1;
		if (!L_3)
		{
			goto IL_0026;
		}
	}
	{
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 194));
		STORE_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 195));
		InvalidCastException_t47FC62F21A3937E814D20381DDACEF240E95AC2E* L_4 = (InvalidCastException_t47FC62F21A3937E814D20381DDACEF240E95AC2E*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&InvalidCastException_t47FC62F21A3937E814D20381DDACEF240E95AC2E_il2cpp_TypeInfo_var)));
		NullCheck(L_4);
		InvalidCastException__ctor_mED3F9781E6CA47A92C602C896EDDF2F40ECB8644(L_4, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteralC51F74D9F7385459B7E90865166418A267D9A62B)), NULL);
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 195));
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_4, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&AudioMixerPlayable__ctor_m2CDDE33FCE0B3F7D9EB482D76515FBF771285F47_RuntimeMethod_var)));
	}

IL_0026:
	{
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 196));
	}

IL_0027:
	{
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 197));
		PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4 L_5 = ___handle0;
		__this->___m_Handle_0 = L_5;
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 198));
		return;
	}
}
IL2CPP_EXTERN_C  void AudioMixerPlayable__ctor_m2CDDE33FCE0B3F7D9EB482D76515FBF771285F47_AdjustorThunk (RuntimeObject* __this, PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4 ___handle0, const RuntimeMethod* method)
{
	AudioMixerPlayable_t6AADDF0C53DF1B4C17969EC24B3B4E4975F3A56C* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<AudioMixerPlayable_t6AADDF0C53DF1B4C17969EC24B3B4E4975F3A56C*>(__this + _offset);
	AudioMixerPlayable__ctor_m2CDDE33FCE0B3F7D9EB482D76515FBF771285F47(_thisAdjusted, ___handle0, method);
}
// UnityEngine.Playables.PlayableHandle UnityEngine.Audio.AudioMixerPlayable::GetHandle()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4 AudioMixerPlayable_GetHandle_m6C182D9794E901D123223BB57738A302BEAB41FD (AudioMixerPlayable_t6AADDF0C53DF1B4C17969EC24B3B4E4975F3A56C* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AudioMixerPlayable_GetHandle_m6C182D9794E901D123223BB57738A302BEAB41FD_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AudioMixerPlayable_t6AADDF0C53DF1B4C17969EC24B3B4E4975F3A56C_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4_0_0_0_var);
		s_Il2CppMethodInitialized = true;
	}
	PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4 V_0;
	memset((&V_0), 0, sizeof(V_0));
	DECLARE_METHOD_THIS(methodExecutionContextThis, (&__this));
	DECLARE_METHOD_EXEC_CTX(methodExecutionContext, AudioMixerPlayable_GetHandle_m6C182D9794E901D123223BB57738A302BEAB41FD_RuntimeMethod_var, methodExecutionContextThis, NULL, NULL);
	CHECK_METHOD_ENTRY_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 199));
	CHECK_METHOD_EXIT_SEQ_POINT(methodExitChecker, methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 200));
	{
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 201));
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 202));
		PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4 L_0 = __this->___m_Handle_0;
		V_0 = L_0;
		goto IL_000a;
	}

IL_000a:
	{
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 203));
		PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4 L_1 = V_0;
		return L_1;
	}
}
IL2CPP_EXTERN_C  PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4 AudioMixerPlayable_GetHandle_m6C182D9794E901D123223BB57738A302BEAB41FD_AdjustorThunk (RuntimeObject* __this, const RuntimeMethod* method)
{
	AudioMixerPlayable_t6AADDF0C53DF1B4C17969EC24B3B4E4975F3A56C* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<AudioMixerPlayable_t6AADDF0C53DF1B4C17969EC24B3B4E4975F3A56C*>(__this + _offset);
	PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4 _returnValue;
	_returnValue = AudioMixerPlayable_GetHandle_m6C182D9794E901D123223BB57738A302BEAB41FD(_thisAdjusted, method);
	return _returnValue;
}
// UnityEngine.Playables.Playable UnityEngine.Audio.AudioMixerPlayable::op_Implicit(UnityEngine.Audio.AudioMixerPlayable)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Playable_t95C6B795846BA0C7D96E4DA14897CCCF2554334F AudioMixerPlayable_op_Implicit_m086F43C4E2E38F40AD37C0F3FF9262A84122BF3B (AudioMixerPlayable_t6AADDF0C53DF1B4C17969EC24B3B4E4975F3A56C ___playable0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AudioMixerPlayable_op_Implicit_m086F43C4E2E38F40AD37C0F3FF9262A84122BF3B_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Playable_t95C6B795846BA0C7D96E4DA14897CCCF2554334F_0_0_0_var);
		s_Il2CppMethodInitialized = true;
	}
	Playable_t95C6B795846BA0C7D96E4DA14897CCCF2554334F V_0;
	memset((&V_0), 0, sizeof(V_0));
	DECLARE_METHOD_PARAMS(methodExecutionContextParameters, (&___playable0));
	DECLARE_METHOD_EXEC_CTX(methodExecutionContext, AudioMixerPlayable_op_Implicit_m086F43C4E2E38F40AD37C0F3FF9262A84122BF3B_RuntimeMethod_var, NULL, methodExecutionContextParameters, NULL);
	CHECK_METHOD_ENTRY_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 204));
	CHECK_METHOD_EXIT_SEQ_POINT(methodExitChecker, methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 205));
	{
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 206));
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 207));
		STORE_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 208));
		PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4 L_0;
		L_0 = AudioMixerPlayable_GetHandle_m6C182D9794E901D123223BB57738A302BEAB41FD((&___playable0), NULL);
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 208));
		STORE_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 209));
		Playable_t95C6B795846BA0C7D96E4DA14897CCCF2554334F L_1;
		memset((&L_1), 0, sizeof(L_1));
		Playable__ctor_mD2EB35E024816AEED68795D0124EAB30E05BF6C4((&L_1), L_0, /*hidden argument*/NULL);
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 209));
		V_0 = L_1;
		goto IL_0010;
	}

IL_0010:
	{
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 210));
		Playable_t95C6B795846BA0C7D96E4DA14897CCCF2554334F L_2 = V_0;
		return L_2;
	}
}
// System.Boolean UnityEngine.Audio.AudioMixerPlayable::Equals(UnityEngine.Audio.AudioMixerPlayable)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool AudioMixerPlayable_Equals_mDFB945EB48199A338BAD00D40FB8EEC34CF64D57 (AudioMixerPlayable_t6AADDF0C53DF1B4C17969EC24B3B4E4975F3A56C* __this, AudioMixerPlayable_t6AADDF0C53DF1B4C17969EC24B3B4E4975F3A56C ___other0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AudioMixerPlayable_Equals_mDFB945EB48199A338BAD00D40FB8EEC34CF64D57_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AudioMixerPlayable_t6AADDF0C53DF1B4C17969EC24B3B4E4975F3A56C_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	bool V_0 = false;
	DECLARE_METHOD_THIS(methodExecutionContextThis, (&__this));
	DECLARE_METHOD_PARAMS(methodExecutionContextParameters, (&___other0));
	DECLARE_METHOD_EXEC_CTX(methodExecutionContext, AudioMixerPlayable_Equals_mDFB945EB48199A338BAD00D40FB8EEC34CF64D57_RuntimeMethod_var, methodExecutionContextThis, methodExecutionContextParameters, NULL);
	CHECK_METHOD_ENTRY_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 211));
	CHECK_METHOD_EXIT_SEQ_POINT(methodExitChecker, methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 212));
	{
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 213));
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 214));
		STORE_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 215));
		PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4 L_0;
		L_0 = AudioMixerPlayable_GetHandle_m6C182D9794E901D123223BB57738A302BEAB41FD(__this, NULL);
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 215));
		STORE_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 216));
		PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4 L_1;
		L_1 = AudioMixerPlayable_GetHandle_m6C182D9794E901D123223BB57738A302BEAB41FD((&___other0), NULL);
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 216));
		STORE_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 217));
		il2cpp_codegen_runtime_class_init_inline(PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4_il2cpp_TypeInfo_var);
		bool L_2;
		L_2 = PlayableHandle_op_Equality_m5E9B847A9D36875C78902727FE36FBEDA4D2D3B9(L_0, L_1, NULL);
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 217));
		V_0 = L_2;
		goto IL_0016;
	}

IL_0016:
	{
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 218));
		bool L_3 = V_0;
		return L_3;
	}
}
IL2CPP_EXTERN_C  bool AudioMixerPlayable_Equals_mDFB945EB48199A338BAD00D40FB8EEC34CF64D57_AdjustorThunk (RuntimeObject* __this, AudioMixerPlayable_t6AADDF0C53DF1B4C17969EC24B3B4E4975F3A56C ___other0, const RuntimeMethod* method)
{
	AudioMixerPlayable_t6AADDF0C53DF1B4C17969EC24B3B4E4975F3A56C* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<AudioMixerPlayable_t6AADDF0C53DF1B4C17969EC24B3B4E4975F3A56C*>(__this + _offset);
	bool _returnValue;
	_returnValue = AudioMixerPlayable_Equals_mDFB945EB48199A338BAD00D40FB8EEC34CF64D57(_thisAdjusted, ___other0, method);
	return _returnValue;
}
// System.Boolean UnityEngine.Audio.AudioMixerPlayable::CreateAudioMixerPlayableInternal(UnityEngine.Playables.PlayableGraph&,System.Boolean,UnityEngine.Playables.PlayableHandle&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool AudioMixerPlayable_CreateAudioMixerPlayableInternal_m7DABB246E18952B463177F30CF4BF3933FF1C14B (PlayableGraph_t4A5B0B45343A240F0761574FD7C672E0CFFF7A6E* ___graph0, bool ___normalizeInputVolumes1, PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4* ___handle2, const RuntimeMethod* method) 
{
	typedef bool (*AudioMixerPlayable_CreateAudioMixerPlayableInternal_m7DABB246E18952B463177F30CF4BF3933FF1C14B_ftn) (PlayableGraph_t4A5B0B45343A240F0761574FD7C672E0CFFF7A6E*, bool, PlayableHandle_t5D6A01EF94382EFEDC047202F71DF882769654D4*);
	static AudioMixerPlayable_CreateAudioMixerPlayableInternal_m7DABB246E18952B463177F30CF4BF3933FF1C14B_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (AudioMixerPlayable_CreateAudioMixerPlayableInternal_m7DABB246E18952B463177F30CF4BF3933FF1C14B_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Audio.AudioMixerPlayable::CreateAudioMixerPlayableInternal(UnityEngine.Playables.PlayableGraph&,System.Boolean,UnityEngine.Playables.PlayableHandle&)");
	bool icallRetVal = _il2cpp_icall_func(___graph0, ___normalizeInputVolumes1, ___handle2);
	return icallRetVal;
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// UnityEngine.Playables.PlayableBinding UnityEngine.Audio.AudioPlayableBinding::Create(System.String,UnityEngine.Object)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR PlayableBinding_tB68B3BAC47F4F4C559640472174D5BEF93CB6AB4 AudioPlayableBinding_Create_mDB746897B08554CCDF9FB4367861DAF364031FBF (String_t* ___name0, Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C* ___key1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AudioPlayableBinding_CreateAudioOutput_m94A81E9E8FC663985A4507892C6B19DD34A7DBA5_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AudioPlayableBinding_Create_mDB746897B08554CCDF9FB4367861DAF364031FBF_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AudioSource_t871AC2272F896738252F04EE949AEF5B241D3299_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&CreateOutputMethod_tD18AFE3B69E6DDD913D82D5FA1D5D909CEEC8509_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&PlayableBinding_tB68B3BAC47F4F4C559640472174D5BEF93CB6AB4_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&PlayableBinding_tB68B3BAC47F4F4C559640472174D5BEF93CB6AB4_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Type_t_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	PlayableBinding_tB68B3BAC47F4F4C559640472174D5BEF93CB6AB4 V_0;
	memset((&V_0), 0, sizeof(V_0));
	DECLARE_METHOD_PARAMS(methodExecutionContextParameters, (&___name0), (&___key1));
	DECLARE_METHOD_EXEC_CTX(methodExecutionContext, AudioPlayableBinding_Create_mDB746897B08554CCDF9FB4367861DAF364031FBF_RuntimeMethod_var, NULL, methodExecutionContextParameters, NULL);
	CHECK_METHOD_ENTRY_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 219));
	CHECK_METHOD_EXIT_SEQ_POINT(methodExitChecker, methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 220));
	{
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 221));
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 222));
		String_t* L_0 = ___name0;
		Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C* L_1 = ___key1;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_2 = { reinterpret_cast<intptr_t> (AudioSource_t871AC2272F896738252F04EE949AEF5B241D3299_0_0_0_var) };
		STORE_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 223));
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_3;
		L_3 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_2, NULL);
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 223));
		STORE_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 224));
		CreateOutputMethod_tD18AFE3B69E6DDD913D82D5FA1D5D909CEEC8509* L_4 = (CreateOutputMethod_tD18AFE3B69E6DDD913D82D5FA1D5D909CEEC8509*)il2cpp_codegen_object_new(CreateOutputMethod_tD18AFE3B69E6DDD913D82D5FA1D5D909CEEC8509_il2cpp_TypeInfo_var);
		NullCheck(L_4);
		CreateOutputMethod__ctor_m5A339017CD8ECB0140EB936FD2A5B589B20166B4(L_4, NULL, (intptr_t)((void*)AudioPlayableBinding_CreateAudioOutput_m94A81E9E8FC663985A4507892C6B19DD34A7DBA5_RuntimeMethod_var), NULL);
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 224));
		STORE_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 225));
		il2cpp_codegen_runtime_class_init_inline(PlayableBinding_tB68B3BAC47F4F4C559640472174D5BEF93CB6AB4_il2cpp_TypeInfo_var);
		PlayableBinding_tB68B3BAC47F4F4C559640472174D5BEF93CB6AB4 L_5;
		L_5 = PlayableBinding_CreateInternal_m4CAAB6FB532F76FEA5BDD52D855F36BDA35517B3(L_0, L_1, L_3, L_4, NULL);
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 225));
		V_0 = L_5;
		goto IL_0021;
	}

IL_0021:
	{
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 226));
		PlayableBinding_tB68B3BAC47F4F4C559640472174D5BEF93CB6AB4 L_6 = V_0;
		return L_6;
	}
}
// UnityEngine.Playables.PlayableOutput UnityEngine.Audio.AudioPlayableBinding::CreateAudioOutput(UnityEngine.Playables.PlayableGraph,System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR PlayableOutput_t2F7C45A58DA3E788EEDDB439549E21CF3FCF3680 AudioPlayableBinding_CreateAudioOutput_m94A81E9E8FC663985A4507892C6B19DD34A7DBA5 (PlayableGraph_t4A5B0B45343A240F0761574FD7C672E0CFFF7A6E ___graph0, String_t* ___name1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AudioPlayableBinding_CreateAudioOutput_m94A81E9E8FC663985A4507892C6B19DD34A7DBA5_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&PlayableOutput_t2F7C45A58DA3E788EEDDB439549E21CF3FCF3680_0_0_0_var);
		s_Il2CppMethodInitialized = true;
	}
	PlayableOutput_t2F7C45A58DA3E788EEDDB439549E21CF3FCF3680 V_0;
	memset((&V_0), 0, sizeof(V_0));
	DECLARE_METHOD_PARAMS(methodExecutionContextParameters, (&___graph0), (&___name1));
	DECLARE_METHOD_EXEC_CTX(methodExecutionContext, AudioPlayableBinding_CreateAudioOutput_m94A81E9E8FC663985A4507892C6B19DD34A7DBA5_RuntimeMethod_var, NULL, methodExecutionContextParameters, NULL);
	CHECK_METHOD_ENTRY_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 227));
	CHECK_METHOD_EXIT_SEQ_POINT(methodExitChecker, methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 228));
	{
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 229));
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 230));
		PlayableGraph_t4A5B0B45343A240F0761574FD7C672E0CFFF7A6E L_0 = ___graph0;
		String_t* L_1 = ___name1;
		STORE_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 231));
		AudioPlayableOutput_tC3DFF8095F429D90129A367EAB98A24F6D6ADF20 L_2;
		L_2 = AudioPlayableOutput_Create_mD99F7F05DC16052F2BD5A268CD4880FC1AF20E83(L_0, L_1, (AudioSource_t871AC2272F896738252F04EE949AEF5B241D3299*)NULL, NULL);
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 231));
		STORE_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 232));
		PlayableOutput_t2F7C45A58DA3E788EEDDB439549E21CF3FCF3680 L_3;
		L_3 = AudioPlayableOutput_op_Implicit_m547B5B8A78353B77C7597270CE50AD3E748A1343(L_2, NULL);
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 232));
		V_0 = L_3;
		goto IL_0011;
	}

IL_0011:
	{
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 233));
		PlayableOutput_t2F7C45A58DA3E788EEDDB439549E21CF3FCF3680 L_4 = V_0;
		return L_4;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Boolean UnityEngine.Audio.AudioPlayableGraphExtensions::InternalCreateAudioOutput(UnityEngine.Playables.PlayableGraph&,System.String,UnityEngine.Playables.PlayableOutputHandle&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool AudioPlayableGraphExtensions_InternalCreateAudioOutput_mE3DD360DD1A748A03C8AF4E42C7ED919CE87AD6C (PlayableGraph_t4A5B0B45343A240F0761574FD7C672E0CFFF7A6E* ___graph0, String_t* ___name1, PlayableOutputHandle_tEB217645A8C0356A3AC6F964F283003B9740E883* ___handle2, const RuntimeMethod* method) 
{
	typedef bool (*AudioPlayableGraphExtensions_InternalCreateAudioOutput_mE3DD360DD1A748A03C8AF4E42C7ED919CE87AD6C_ftn) (PlayableGraph_t4A5B0B45343A240F0761574FD7C672E0CFFF7A6E*, String_t*, PlayableOutputHandle_tEB217645A8C0356A3AC6F964F283003B9740E883*);
	static AudioPlayableGraphExtensions_InternalCreateAudioOutput_mE3DD360DD1A748A03C8AF4E42C7ED919CE87AD6C_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (AudioPlayableGraphExtensions_InternalCreateAudioOutput_mE3DD360DD1A748A03C8AF4E42C7ED919CE87AD6C_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Audio.AudioPlayableGraphExtensions::InternalCreateAudioOutput(UnityEngine.Playables.PlayableGraph&,System.String,UnityEngine.Playables.PlayableOutputHandle&)");
	bool icallRetVal = _il2cpp_icall_func(___graph0, ___name1, ___handle2);
	return icallRetVal;
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// UnityEngine.Audio.AudioPlayableOutput UnityEngine.Audio.AudioPlayableOutput::Create(UnityEngine.Playables.PlayableGraph,System.String,UnityEngine.AudioSource)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR AudioPlayableOutput_tC3DFF8095F429D90129A367EAB98A24F6D6ADF20 AudioPlayableOutput_Create_mD99F7F05DC16052F2BD5A268CD4880FC1AF20E83 (PlayableGraph_t4A5B0B45343A240F0761574FD7C672E0CFFF7A6E ___graph0, String_t* ___name1, AudioSource_t871AC2272F896738252F04EE949AEF5B241D3299* ___target2, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AudioPlayableOutput_Create_mD99F7F05DC16052F2BD5A268CD4880FC1AF20E83_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AudioPlayableOutput_tC3DFF8095F429D90129A367EAB98A24F6D6ADF20_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&PlayableOutputHandle_tEB217645A8C0356A3AC6F964F283003B9740E883_0_0_0_var);
		s_Il2CppMethodInitialized = true;
	}
	PlayableOutputHandle_tEB217645A8C0356A3AC6F964F283003B9740E883 V_0;
	memset((&V_0), 0, sizeof(V_0));
	AudioPlayableOutput_tC3DFF8095F429D90129A367EAB98A24F6D6ADF20 V_1;
	memset((&V_1), 0, sizeof(V_1));
	bool V_2 = false;
	AudioPlayableOutput_tC3DFF8095F429D90129A367EAB98A24F6D6ADF20 V_3;
	memset((&V_3), 0, sizeof(V_3));
	DECLARE_METHOD_PARAMS(methodExecutionContextParameters, (&___graph0), (&___name1), (&___target2));
	DECLARE_METHOD_LOCALS(methodExecutionContextLocals, (&V_0), (&V_1));
	DECLARE_METHOD_EXEC_CTX(methodExecutionContext, AudioPlayableOutput_Create_mD99F7F05DC16052F2BD5A268CD4880FC1AF20E83_RuntimeMethod_var, NULL, methodExecutionContextParameters, methodExecutionContextLocals);
	CHECK_METHOD_ENTRY_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 234));
	CHECK_METHOD_EXIT_SEQ_POINT(methodExitChecker, methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 235));
	{
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 236));
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 237));
		String_t* L_0 = ___name1;
		STORE_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 238));
		bool L_1;
		L_1 = AudioPlayableGraphExtensions_InternalCreateAudioOutput_mE3DD360DD1A748A03C8AF4E42C7ED919CE87AD6C((&___graph0), L_0, (&V_0), NULL);
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 238));
		V_2 = (bool)((((int32_t)L_1) == ((int32_t)0))? 1 : 0);
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 239));
		bool L_2 = V_2;
		if (!L_2)
		{
			goto IL_001a;
		}
	}
	{
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 240));
		STORE_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 241));
		AudioPlayableOutput_tC3DFF8095F429D90129A367EAB98A24F6D6ADF20 L_3;
		L_3 = AudioPlayableOutput_get_Null_mFCED339CCA2255F4E9AB256BEEB19E0374AA16F3(NULL);
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 241));
		V_3 = L_3;
		goto IL_002f;
	}

IL_001a:
	{
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 242));
		PlayableOutputHandle_tEB217645A8C0356A3AC6F964F283003B9740E883 L_4 = V_0;
		STORE_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 243));
		AudioPlayableOutput__ctor_mBEA3D7EE652908558720EDC0D40F7BF3EC50D409((&V_1), L_4, NULL);
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 243));
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 244));
		AudioSource_t871AC2272F896738252F04EE949AEF5B241D3299* L_5 = ___target2;
		STORE_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 245));
		AudioPlayableOutput_SetTarget_m34EE86E5C2833F12993681ABE5AC85961836DE04((&V_1), L_5, NULL);
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 245));
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 246));
		AudioPlayableOutput_tC3DFF8095F429D90129A367EAB98A24F6D6ADF20 L_6 = V_1;
		V_3 = L_6;
		goto IL_002f;
	}

IL_002f:
	{
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 247));
		AudioPlayableOutput_tC3DFF8095F429D90129A367EAB98A24F6D6ADF20 L_7 = V_3;
		return L_7;
	}
}
// System.Void UnityEngine.Audio.AudioPlayableOutput::.ctor(UnityEngine.Playables.PlayableOutputHandle)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AudioPlayableOutput__ctor_mBEA3D7EE652908558720EDC0D40F7BF3EC50D409 (AudioPlayableOutput_tC3DFF8095F429D90129A367EAB98A24F6D6ADF20* __this, PlayableOutputHandle_tEB217645A8C0356A3AC6F964F283003B9740E883 ___handle0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AudioPlayableOutput__ctor_mBEA3D7EE652908558720EDC0D40F7BF3EC50D409_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AudioPlayableOutput_tC3DFF8095F429D90129A367EAB98A24F6D6ADF20_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&PlayableOutputHandle_IsPlayableOutputOfType_TisAudioPlayableOutput_tC3DFF8095F429D90129A367EAB98A24F6D6ADF20_mAC4BC6AF8D183B1A972EA239A6D9BEA34054C7C6_RuntimeMethod_var);
		s_Il2CppMethodInitialized = true;
	}
	bool V_0 = false;
	bool V_1 = false;
	DECLARE_METHOD_THIS(methodExecutionContextThis, (&__this));
	DECLARE_METHOD_PARAMS(methodExecutionContextParameters, (&___handle0));
	DECLARE_METHOD_EXEC_CTX(methodExecutionContext, AudioPlayableOutput__ctor_mBEA3D7EE652908558720EDC0D40F7BF3EC50D409_RuntimeMethod_var, methodExecutionContextThis, methodExecutionContextParameters, NULL);
	CHECK_METHOD_ENTRY_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 248));
	CHECK_METHOD_EXIT_SEQ_POINT(methodExitChecker, methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 249));
	{
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 250));
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 251));
		STORE_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 252));
		bool L_0;
		L_0 = PlayableOutputHandle_IsValid_mA94C343D72B72C3B1C7636C93A8DB5EA71691312((&___handle0), NULL);
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 252));
		V_0 = L_0;
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 253));
		bool L_1 = V_0;
		if (!L_1)
		{
			goto IL_0027;
		}
	}
	{
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 254));
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 255));
		STORE_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 256));
		bool L_2;
		L_2 = PlayableOutputHandle_IsPlayableOutputOfType_TisAudioPlayableOutput_tC3DFF8095F429D90129A367EAB98A24F6D6ADF20_mAC4BC6AF8D183B1A972EA239A6D9BEA34054C7C6((&___handle0), PlayableOutputHandle_IsPlayableOutputOfType_TisAudioPlayableOutput_tC3DFF8095F429D90129A367EAB98A24F6D6ADF20_mAC4BC6AF8D183B1A972EA239A6D9BEA34054C7C6_RuntimeMethod_var);
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 256));
		V_1 = (bool)((((int32_t)L_2) == ((int32_t)0))? 1 : 0);
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 257));
		bool L_3 = V_1;
		if (!L_3)
		{
			goto IL_0026;
		}
	}
	{
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 258));
		STORE_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 259));
		InvalidCastException_t47FC62F21A3937E814D20381DDACEF240E95AC2E* L_4 = (InvalidCastException_t47FC62F21A3937E814D20381DDACEF240E95AC2E*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&InvalidCastException_t47FC62F21A3937E814D20381DDACEF240E95AC2E_il2cpp_TypeInfo_var)));
		NullCheck(L_4);
		InvalidCastException__ctor_mED3F9781E6CA47A92C602C896EDDF2F40ECB8644(L_4, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteralD7EA9435CDE6F5B13E32FE646D502752ECCD43DD)), NULL);
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 259));
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_4, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&AudioPlayableOutput__ctor_mBEA3D7EE652908558720EDC0D40F7BF3EC50D409_RuntimeMethod_var)));
	}

IL_0026:
	{
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 260));
	}

IL_0027:
	{
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 261));
		PlayableOutputHandle_tEB217645A8C0356A3AC6F964F283003B9740E883 L_5 = ___handle0;
		__this->___m_Handle_0 = L_5;
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 262));
		return;
	}
}
IL2CPP_EXTERN_C  void AudioPlayableOutput__ctor_mBEA3D7EE652908558720EDC0D40F7BF3EC50D409_AdjustorThunk (RuntimeObject* __this, PlayableOutputHandle_tEB217645A8C0356A3AC6F964F283003B9740E883 ___handle0, const RuntimeMethod* method)
{
	AudioPlayableOutput_tC3DFF8095F429D90129A367EAB98A24F6D6ADF20* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<AudioPlayableOutput_tC3DFF8095F429D90129A367EAB98A24F6D6ADF20*>(__this + _offset);
	AudioPlayableOutput__ctor_mBEA3D7EE652908558720EDC0D40F7BF3EC50D409(_thisAdjusted, ___handle0, method);
}
// UnityEngine.Audio.AudioPlayableOutput UnityEngine.Audio.AudioPlayableOutput::get_Null()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR AudioPlayableOutput_tC3DFF8095F429D90129A367EAB98A24F6D6ADF20 AudioPlayableOutput_get_Null_mFCED339CCA2255F4E9AB256BEEB19E0374AA16F3 (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AudioPlayableOutput_get_Null_mFCED339CCA2255F4E9AB256BEEB19E0374AA16F3_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AudioPlayableOutput_tC3DFF8095F429D90129A367EAB98A24F6D6ADF20_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&PlayableOutputHandle_tEB217645A8C0356A3AC6F964F283003B9740E883_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	AudioPlayableOutput_tC3DFF8095F429D90129A367EAB98A24F6D6ADF20 V_0;
	memset((&V_0), 0, sizeof(V_0));
	DECLARE_METHOD_EXEC_CTX(methodExecutionContext, AudioPlayableOutput_get_Null_mFCED339CCA2255F4E9AB256BEEB19E0374AA16F3_RuntimeMethod_var, NULL, NULL, NULL);
	CHECK_METHOD_ENTRY_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 263));
	CHECK_METHOD_EXIT_SEQ_POINT(methodExitChecker, methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 264));
	{
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 265));
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 266));
		STORE_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 267));
		il2cpp_codegen_runtime_class_init_inline(PlayableOutputHandle_tEB217645A8C0356A3AC6F964F283003B9740E883_il2cpp_TypeInfo_var);
		PlayableOutputHandle_tEB217645A8C0356A3AC6F964F283003B9740E883 L_0;
		L_0 = PlayableOutputHandle_get_Null_m4ECA1C6CE17D440F3EC5E2FD03E4D59FF20554DE(NULL);
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 267));
		STORE_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 268));
		AudioPlayableOutput_tC3DFF8095F429D90129A367EAB98A24F6D6ADF20 L_1;
		memset((&L_1), 0, sizeof(L_1));
		AudioPlayableOutput__ctor_mBEA3D7EE652908558720EDC0D40F7BF3EC50D409((&L_1), L_0, /*hidden argument*/NULL);
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 268));
		V_0 = L_1;
		goto IL_000e;
	}

IL_000e:
	{
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 269));
		AudioPlayableOutput_tC3DFF8095F429D90129A367EAB98A24F6D6ADF20 L_2 = V_0;
		return L_2;
	}
}
// UnityEngine.Playables.PlayableOutputHandle UnityEngine.Audio.AudioPlayableOutput::GetHandle()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR PlayableOutputHandle_tEB217645A8C0356A3AC6F964F283003B9740E883 AudioPlayableOutput_GetHandle_m55153D572F8FB9BCFF3843402A20280273B934AE (AudioPlayableOutput_tC3DFF8095F429D90129A367EAB98A24F6D6ADF20* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AudioPlayableOutput_GetHandle_m55153D572F8FB9BCFF3843402A20280273B934AE_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AudioPlayableOutput_tC3DFF8095F429D90129A367EAB98A24F6D6ADF20_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&PlayableOutputHandle_tEB217645A8C0356A3AC6F964F283003B9740E883_0_0_0_var);
		s_Il2CppMethodInitialized = true;
	}
	PlayableOutputHandle_tEB217645A8C0356A3AC6F964F283003B9740E883 V_0;
	memset((&V_0), 0, sizeof(V_0));
	DECLARE_METHOD_THIS(methodExecutionContextThis, (&__this));
	DECLARE_METHOD_EXEC_CTX(methodExecutionContext, AudioPlayableOutput_GetHandle_m55153D572F8FB9BCFF3843402A20280273B934AE_RuntimeMethod_var, methodExecutionContextThis, NULL, NULL);
	CHECK_METHOD_ENTRY_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 270));
	CHECK_METHOD_EXIT_SEQ_POINT(methodExitChecker, methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 271));
	{
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 272));
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 273));
		PlayableOutputHandle_tEB217645A8C0356A3AC6F964F283003B9740E883 L_0 = __this->___m_Handle_0;
		V_0 = L_0;
		goto IL_000a;
	}

IL_000a:
	{
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 274));
		PlayableOutputHandle_tEB217645A8C0356A3AC6F964F283003B9740E883 L_1 = V_0;
		return L_1;
	}
}
IL2CPP_EXTERN_C  PlayableOutputHandle_tEB217645A8C0356A3AC6F964F283003B9740E883 AudioPlayableOutput_GetHandle_m55153D572F8FB9BCFF3843402A20280273B934AE_AdjustorThunk (RuntimeObject* __this, const RuntimeMethod* method)
{
	AudioPlayableOutput_tC3DFF8095F429D90129A367EAB98A24F6D6ADF20* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<AudioPlayableOutput_tC3DFF8095F429D90129A367EAB98A24F6D6ADF20*>(__this + _offset);
	PlayableOutputHandle_tEB217645A8C0356A3AC6F964F283003B9740E883 _returnValue;
	_returnValue = AudioPlayableOutput_GetHandle_m55153D572F8FB9BCFF3843402A20280273B934AE(_thisAdjusted, method);
	return _returnValue;
}
// UnityEngine.Playables.PlayableOutput UnityEngine.Audio.AudioPlayableOutput::op_Implicit(UnityEngine.Audio.AudioPlayableOutput)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR PlayableOutput_t2F7C45A58DA3E788EEDDB439549E21CF3FCF3680 AudioPlayableOutput_op_Implicit_m547B5B8A78353B77C7597270CE50AD3E748A1343 (AudioPlayableOutput_tC3DFF8095F429D90129A367EAB98A24F6D6ADF20 ___output0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AudioPlayableOutput_op_Implicit_m547B5B8A78353B77C7597270CE50AD3E748A1343_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&PlayableOutput_t2F7C45A58DA3E788EEDDB439549E21CF3FCF3680_0_0_0_var);
		s_Il2CppMethodInitialized = true;
	}
	PlayableOutput_t2F7C45A58DA3E788EEDDB439549E21CF3FCF3680 V_0;
	memset((&V_0), 0, sizeof(V_0));
	DECLARE_METHOD_PARAMS(methodExecutionContextParameters, (&___output0));
	DECLARE_METHOD_EXEC_CTX(methodExecutionContext, AudioPlayableOutput_op_Implicit_m547B5B8A78353B77C7597270CE50AD3E748A1343_RuntimeMethod_var, NULL, methodExecutionContextParameters, NULL);
	CHECK_METHOD_ENTRY_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 275));
	CHECK_METHOD_EXIT_SEQ_POINT(methodExitChecker, methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 276));
	{
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 277));
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 278));
		STORE_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 279));
		PlayableOutputHandle_tEB217645A8C0356A3AC6F964F283003B9740E883 L_0;
		L_0 = AudioPlayableOutput_GetHandle_m55153D572F8FB9BCFF3843402A20280273B934AE((&___output0), NULL);
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 279));
		STORE_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 280));
		PlayableOutput_t2F7C45A58DA3E788EEDDB439549E21CF3FCF3680 L_1;
		memset((&L_1), 0, sizeof(L_1));
		PlayableOutput__ctor_m55FBB20EC479F67641835EA48D84A1AB3DF39747((&L_1), L_0, /*hidden argument*/NULL);
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 280));
		V_0 = L_1;
		goto IL_0010;
	}

IL_0010:
	{
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 281));
		PlayableOutput_t2F7C45A58DA3E788EEDDB439549E21CF3FCF3680 L_2 = V_0;
		return L_2;
	}
}
// UnityEngine.Audio.AudioPlayableOutput UnityEngine.Audio.AudioPlayableOutput::op_Explicit(UnityEngine.Playables.PlayableOutput)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR AudioPlayableOutput_tC3DFF8095F429D90129A367EAB98A24F6D6ADF20 AudioPlayableOutput_op_Explicit_m9E8EE0C49D33D0BF5749858B388D9B42F885FCAC (PlayableOutput_t2F7C45A58DA3E788EEDDB439549E21CF3FCF3680 ___output0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AudioPlayableOutput_op_Explicit_m9E8EE0C49D33D0BF5749858B388D9B42F885FCAC_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AudioPlayableOutput_tC3DFF8095F429D90129A367EAB98A24F6D6ADF20_0_0_0_var);
		s_Il2CppMethodInitialized = true;
	}
	AudioPlayableOutput_tC3DFF8095F429D90129A367EAB98A24F6D6ADF20 V_0;
	memset((&V_0), 0, sizeof(V_0));
	DECLARE_METHOD_PARAMS(methodExecutionContextParameters, (&___output0));
	DECLARE_METHOD_EXEC_CTX(methodExecutionContext, AudioPlayableOutput_op_Explicit_m9E8EE0C49D33D0BF5749858B388D9B42F885FCAC_RuntimeMethod_var, NULL, methodExecutionContextParameters, NULL);
	CHECK_METHOD_ENTRY_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 282));
	CHECK_METHOD_EXIT_SEQ_POINT(methodExitChecker, methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 283));
	{
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 284));
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 285));
		STORE_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 286));
		PlayableOutputHandle_tEB217645A8C0356A3AC6F964F283003B9740E883 L_0;
		L_0 = PlayableOutput_GetHandle_m12FF2889D15884CBEB92A6CB376827EBA5A607BF((&___output0), NULL);
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 286));
		STORE_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 287));
		AudioPlayableOutput_tC3DFF8095F429D90129A367EAB98A24F6D6ADF20 L_1;
		memset((&L_1), 0, sizeof(L_1));
		AudioPlayableOutput__ctor_mBEA3D7EE652908558720EDC0D40F7BF3EC50D409((&L_1), L_0, /*hidden argument*/NULL);
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 287));
		V_0 = L_1;
		goto IL_0010;
	}

IL_0010:
	{
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 288));
		AudioPlayableOutput_tC3DFF8095F429D90129A367EAB98A24F6D6ADF20 L_2 = V_0;
		return L_2;
	}
}
// System.Void UnityEngine.Audio.AudioPlayableOutput::SetTarget(UnityEngine.AudioSource)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AudioPlayableOutput_SetTarget_m34EE86E5C2833F12993681ABE5AC85961836DE04 (AudioPlayableOutput_tC3DFF8095F429D90129A367EAB98A24F6D6ADF20* __this, AudioSource_t871AC2272F896738252F04EE949AEF5B241D3299* ___value0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AudioPlayableOutput_SetTarget_m34EE86E5C2833F12993681ABE5AC85961836DE04_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AudioPlayableOutput_tC3DFF8095F429D90129A367EAB98A24F6D6ADF20_0_0_0_var);
		s_Il2CppMethodInitialized = true;
	}
	DECLARE_METHOD_THIS(methodExecutionContextThis, (&__this));
	DECLARE_METHOD_PARAMS(methodExecutionContextParameters, (&___value0));
	DECLARE_METHOD_EXEC_CTX(methodExecutionContext, AudioPlayableOutput_SetTarget_m34EE86E5C2833F12993681ABE5AC85961836DE04_RuntimeMethod_var, methodExecutionContextThis, methodExecutionContextParameters, NULL);
	CHECK_METHOD_ENTRY_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 289));
	CHECK_METHOD_EXIT_SEQ_POINT(methodExitChecker, methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 290));
	{
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 291));
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 292));
		PlayableOutputHandle_tEB217645A8C0356A3AC6F964F283003B9740E883* L_0 = (&__this->___m_Handle_0);
		AudioSource_t871AC2272F896738252F04EE949AEF5B241D3299* L_1 = ___value0;
		STORE_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 293));
		AudioPlayableOutput_InternalSetTarget_m79848832BFF56C8AFFD196E429652449E8DEC7DA(L_0, L_1, NULL);
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 293));
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 294));
		return;
	}
}
IL2CPP_EXTERN_C  void AudioPlayableOutput_SetTarget_m34EE86E5C2833F12993681ABE5AC85961836DE04_AdjustorThunk (RuntimeObject* __this, AudioSource_t871AC2272F896738252F04EE949AEF5B241D3299* ___value0, const RuntimeMethod* method)
{
	AudioPlayableOutput_tC3DFF8095F429D90129A367EAB98A24F6D6ADF20* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<AudioPlayableOutput_tC3DFF8095F429D90129A367EAB98A24F6D6ADF20*>(__this + _offset);
	AudioPlayableOutput_SetTarget_m34EE86E5C2833F12993681ABE5AC85961836DE04(_thisAdjusted, ___value0, method);
}
// System.Void UnityEngine.Audio.AudioPlayableOutput::SetEvaluateOnSeek(System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AudioPlayableOutput_SetEvaluateOnSeek_mB3266A8A68E94933A82A0C431B7A2E7321929D92 (AudioPlayableOutput_tC3DFF8095F429D90129A367EAB98A24F6D6ADF20* __this, bool ___value0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AudioPlayableOutput_SetEvaluateOnSeek_mB3266A8A68E94933A82A0C431B7A2E7321929D92_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AudioPlayableOutput_tC3DFF8095F429D90129A367EAB98A24F6D6ADF20_0_0_0_var);
		s_Il2CppMethodInitialized = true;
	}
	DECLARE_METHOD_THIS(methodExecutionContextThis, (&__this));
	DECLARE_METHOD_PARAMS(methodExecutionContextParameters, (&___value0));
	DECLARE_METHOD_EXEC_CTX(methodExecutionContext, AudioPlayableOutput_SetEvaluateOnSeek_mB3266A8A68E94933A82A0C431B7A2E7321929D92_RuntimeMethod_var, methodExecutionContextThis, methodExecutionContextParameters, NULL);
	CHECK_METHOD_ENTRY_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 295));
	CHECK_METHOD_EXIT_SEQ_POINT(methodExitChecker, methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 296));
	{
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 297));
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 298));
		PlayableOutputHandle_tEB217645A8C0356A3AC6F964F283003B9740E883* L_0 = (&__this->___m_Handle_0);
		bool L_1 = ___value0;
		STORE_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 299));
		AudioPlayableOutput_InternalSetEvaluateOnSeek_mBA74AB313B981B267A663D298B89F8113602ECB1(L_0, L_1, NULL);
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 299));
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 300));
		return;
	}
}
IL2CPP_EXTERN_C  void AudioPlayableOutput_SetEvaluateOnSeek_mB3266A8A68E94933A82A0C431B7A2E7321929D92_AdjustorThunk (RuntimeObject* __this, bool ___value0, const RuntimeMethod* method)
{
	AudioPlayableOutput_tC3DFF8095F429D90129A367EAB98A24F6D6ADF20* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<AudioPlayableOutput_tC3DFF8095F429D90129A367EAB98A24F6D6ADF20*>(__this + _offset);
	AudioPlayableOutput_SetEvaluateOnSeek_mB3266A8A68E94933A82A0C431B7A2E7321929D92(_thisAdjusted, ___value0, method);
}
// System.Void UnityEngine.Audio.AudioPlayableOutput::InternalSetTarget(UnityEngine.Playables.PlayableOutputHandle&,UnityEngine.AudioSource)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AudioPlayableOutput_InternalSetTarget_m79848832BFF56C8AFFD196E429652449E8DEC7DA (PlayableOutputHandle_tEB217645A8C0356A3AC6F964F283003B9740E883* ___output0, AudioSource_t871AC2272F896738252F04EE949AEF5B241D3299* ___target1, const RuntimeMethod* method) 
{
	typedef void (*AudioPlayableOutput_InternalSetTarget_m79848832BFF56C8AFFD196E429652449E8DEC7DA_ftn) (PlayableOutputHandle_tEB217645A8C0356A3AC6F964F283003B9740E883*, AudioSource_t871AC2272F896738252F04EE949AEF5B241D3299*);
	static AudioPlayableOutput_InternalSetTarget_m79848832BFF56C8AFFD196E429652449E8DEC7DA_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (AudioPlayableOutput_InternalSetTarget_m79848832BFF56C8AFFD196E429652449E8DEC7DA_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Audio.AudioPlayableOutput::InternalSetTarget(UnityEngine.Playables.PlayableOutputHandle&,UnityEngine.AudioSource)");
	_il2cpp_icall_func(___output0, ___target1);
}
// System.Void UnityEngine.Audio.AudioPlayableOutput::InternalSetEvaluateOnSeek(UnityEngine.Playables.PlayableOutputHandle&,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AudioPlayableOutput_InternalSetEvaluateOnSeek_mBA74AB313B981B267A663D298B89F8113602ECB1 (PlayableOutputHandle_tEB217645A8C0356A3AC6F964F283003B9740E883* ___output0, bool ___value1, const RuntimeMethod* method) 
{
	typedef void (*AudioPlayableOutput_InternalSetEvaluateOnSeek_mBA74AB313B981B267A663D298B89F8113602ECB1_ftn) (PlayableOutputHandle_tEB217645A8C0356A3AC6F964F283003B9740E883*, bool);
	static AudioPlayableOutput_InternalSetEvaluateOnSeek_mBA74AB313B981B267A663D298B89F8113602ECB1_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (AudioPlayableOutput_InternalSetEvaluateOnSeek_mBA74AB313B981B267A663D298B89F8113602ECB1_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Audio.AudioPlayableOutput::InternalSetEvaluateOnSeek(UnityEngine.Playables.PlayableOutputHandle&,System.Boolean)");
	_il2cpp_icall_func(___output0, ___value1);
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void UnityEngine.Experimental.Audio.AudioSampleProvider::InvokeSampleFramesAvailable(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AudioSampleProvider_InvokeSampleFramesAvailable_mEB16F7230AB65A3576BF053AC5719F8E134FBCD4 (AudioSampleProvider_t602353124A2F6F2AEC38E56C3C21932344F712E2* __this, int32_t ___sampleFrameCount0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AudioSampleProvider_InvokeSampleFramesAvailable_mEB16F7230AB65A3576BF053AC5719F8E134FBCD4_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AudioSampleProvider_t602353124A2F6F2AEC38E56C3C21932344F712E2_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_0_0_0_var);
		s_Il2CppMethodInitialized = true;
	}
	bool V_0 = false;
	DECLARE_METHOD_THIS(methodExecutionContextThis, (&__this));
	DECLARE_METHOD_PARAMS(methodExecutionContextParameters, (&___sampleFrameCount0));
	DECLARE_METHOD_EXEC_CTX(methodExecutionContext, AudioSampleProvider_InvokeSampleFramesAvailable_mEB16F7230AB65A3576BF053AC5719F8E134FBCD4_RuntimeMethod_var, methodExecutionContextThis, methodExecutionContextParameters, NULL);
	CHECK_METHOD_ENTRY_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 301));
	CHECK_METHOD_EXIT_SEQ_POINT(methodExitChecker, methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 302));
	{
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 303));
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 304));
		SampleFramesHandler_tFE84FF9BBCEFB880D46227188F375BEF680AAA30* L_0 = __this->___sampleFramesAvailable_0;
		V_0 = (bool)((!(((RuntimeObject*)(SampleFramesHandler_tFE84FF9BBCEFB880D46227188F375BEF680AAA30*)L_0) <= ((RuntimeObject*)(RuntimeObject*)NULL)))? 1 : 0);
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 305));
		bool L_1 = V_0;
		if (!L_1)
		{
			goto IL_001c;
		}
	}
	{
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 306));
		SampleFramesHandler_tFE84FF9BBCEFB880D46227188F375BEF680AAA30* L_2 = __this->___sampleFramesAvailable_0;
		int32_t L_3 = ___sampleFrameCount0;
		STORE_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 307));
		NullCheck(L_2);
		SampleFramesHandler_Invoke_m478D5645634B8C734E58B59CF7750797FC54F1BC_inline(L_2, __this, L_3, NULL);
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 307));
	}

IL_001c:
	{
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 308));
		return;
	}
}
// System.Void UnityEngine.Experimental.Audio.AudioSampleProvider::InvokeSampleFramesOverflow(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AudioSampleProvider_InvokeSampleFramesOverflow_m66593173A527981F5EB2A5EF77B0C9119DAB5E15 (AudioSampleProvider_t602353124A2F6F2AEC38E56C3C21932344F712E2* __this, int32_t ___droppedSampleFrameCount0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AudioSampleProvider_InvokeSampleFramesOverflow_m66593173A527981F5EB2A5EF77B0C9119DAB5E15_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AudioSampleProvider_t602353124A2F6F2AEC38E56C3C21932344F712E2_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_0_0_0_var);
		s_Il2CppMethodInitialized = true;
	}
	bool V_0 = false;
	DECLARE_METHOD_THIS(methodExecutionContextThis, (&__this));
	DECLARE_METHOD_PARAMS(methodExecutionContextParameters, (&___droppedSampleFrameCount0));
	DECLARE_METHOD_EXEC_CTX(methodExecutionContext, AudioSampleProvider_InvokeSampleFramesOverflow_m66593173A527981F5EB2A5EF77B0C9119DAB5E15_RuntimeMethod_var, methodExecutionContextThis, methodExecutionContextParameters, NULL);
	CHECK_METHOD_ENTRY_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 309));
	CHECK_METHOD_EXIT_SEQ_POINT(methodExitChecker, methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 310));
	{
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 311));
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 312));
		SampleFramesHandler_tFE84FF9BBCEFB880D46227188F375BEF680AAA30* L_0 = __this->___sampleFramesOverflow_1;
		V_0 = (bool)((!(((RuntimeObject*)(SampleFramesHandler_tFE84FF9BBCEFB880D46227188F375BEF680AAA30*)L_0) <= ((RuntimeObject*)(RuntimeObject*)NULL)))? 1 : 0);
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 313));
		bool L_1 = V_0;
		if (!L_1)
		{
			goto IL_001c;
		}
	}
	{
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 314));
		SampleFramesHandler_tFE84FF9BBCEFB880D46227188F375BEF680AAA30* L_2 = __this->___sampleFramesOverflow_1;
		int32_t L_3 = ___droppedSampleFrameCount0;
		STORE_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 315));
		NullCheck(L_2);
		SampleFramesHandler_Invoke_m478D5645634B8C734E58B59CF7750797FC54F1BC_inline(L_2, __this, L_3, NULL);
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 315));
	}

IL_001c:
	{
		CHECK_SEQ_POINT(methodExecutionContext, (g_sequencePointsUnityEngine_AudioModule + 316));
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
void SampleFramesHandler_Invoke_m478D5645634B8C734E58B59CF7750797FC54F1BC_Multicast(SampleFramesHandler_tFE84FF9BBCEFB880D46227188F375BEF680AAA30* __this, AudioSampleProvider_t602353124A2F6F2AEC38E56C3C21932344F712E2* ___provider0, uint32_t ___sampleFrameCount1, const RuntimeMethod* method)
{
	il2cpp_array_size_t length = __this->___delegates_13->max_length;
	Delegate_t** delegatesToInvoke = reinterpret_cast<Delegate_t**>(__this->___delegates_13->GetAddressAtUnchecked(0));
	for (il2cpp_array_size_t i = 0; i < length; i++)
	{
		SampleFramesHandler_tFE84FF9BBCEFB880D46227188F375BEF680AAA30* currentDelegate = reinterpret_cast<SampleFramesHandler_tFE84FF9BBCEFB880D46227188F375BEF680AAA30*>(delegatesToInvoke[i]);
		typedef void (*FunctionPointerType) (RuntimeObject*, AudioSampleProvider_t602353124A2F6F2AEC38E56C3C21932344F712E2*, uint32_t, const RuntimeMethod*);
		((FunctionPointerType)currentDelegate->___invoke_impl_1)((Il2CppObject*)currentDelegate->___method_code_6, ___provider0, ___sampleFrameCount1, reinterpret_cast<RuntimeMethod*>(currentDelegate->___method_3));
	}
}
void SampleFramesHandler_Invoke_m478D5645634B8C734E58B59CF7750797FC54F1BC_OpenInst(SampleFramesHandler_tFE84FF9BBCEFB880D46227188F375BEF680AAA30* __this, AudioSampleProvider_t602353124A2F6F2AEC38E56C3C21932344F712E2* ___provider0, uint32_t ___sampleFrameCount1, const RuntimeMethod* method)
{
	NullCheck(___provider0);
	typedef void (*FunctionPointerType) (AudioSampleProvider_t602353124A2F6F2AEC38E56C3C21932344F712E2*, uint32_t, const RuntimeMethod*);
	((FunctionPointerType)__this->___method_ptr_0)(___provider0, ___sampleFrameCount1, method);
}
void SampleFramesHandler_Invoke_m478D5645634B8C734E58B59CF7750797FC54F1BC_OpenStatic(SampleFramesHandler_tFE84FF9BBCEFB880D46227188F375BEF680AAA30* __this, AudioSampleProvider_t602353124A2F6F2AEC38E56C3C21932344F712E2* ___provider0, uint32_t ___sampleFrameCount1, const RuntimeMethod* method)
{
	typedef void (*FunctionPointerType) (AudioSampleProvider_t602353124A2F6F2AEC38E56C3C21932344F712E2*, uint32_t, const RuntimeMethod*);
	((FunctionPointerType)__this->___method_ptr_0)(___provider0, ___sampleFrameCount1, method);
}
void SampleFramesHandler_Invoke_m478D5645634B8C734E58B59CF7750797FC54F1BC_OpenStaticInvoker(SampleFramesHandler_tFE84FF9BBCEFB880D46227188F375BEF680AAA30* __this, AudioSampleProvider_t602353124A2F6F2AEC38E56C3C21932344F712E2* ___provider0, uint32_t ___sampleFrameCount1, const RuntimeMethod* method)
{
	InvokerActionInvoker2< AudioSampleProvider_t602353124A2F6F2AEC38E56C3C21932344F712E2*, uint32_t >::Invoke(__this->___method_ptr_0, method, NULL, ___provider0, ___sampleFrameCount1);
}
void SampleFramesHandler_Invoke_m478D5645634B8C734E58B59CF7750797FC54F1BC_ClosedStaticInvoker(SampleFramesHandler_tFE84FF9BBCEFB880D46227188F375BEF680AAA30* __this, AudioSampleProvider_t602353124A2F6F2AEC38E56C3C21932344F712E2* ___provider0, uint32_t ___sampleFrameCount1, const RuntimeMethod* method)
{
	InvokerActionInvoker3< RuntimeObject*, AudioSampleProvider_t602353124A2F6F2AEC38E56C3C21932344F712E2*, uint32_t >::Invoke(__this->___method_ptr_0, method, NULL, __this->___m_target_2, ___provider0, ___sampleFrameCount1);
}
void SampleFramesHandler_Invoke_m478D5645634B8C734E58B59CF7750797FC54F1BC_OpenVirtual(SampleFramesHandler_tFE84FF9BBCEFB880D46227188F375BEF680AAA30* __this, AudioSampleProvider_t602353124A2F6F2AEC38E56C3C21932344F712E2* ___provider0, uint32_t ___sampleFrameCount1, const RuntimeMethod* method)
{
	NullCheck(___provider0);
	VirtualActionInvoker1< uint32_t >::Invoke(il2cpp_codegen_method_get_slot(method), ___provider0, ___sampleFrameCount1);
}
void SampleFramesHandler_Invoke_m478D5645634B8C734E58B59CF7750797FC54F1BC_OpenInterface(SampleFramesHandler_tFE84FF9BBCEFB880D46227188F375BEF680AAA30* __this, AudioSampleProvider_t602353124A2F6F2AEC38E56C3C21932344F712E2* ___provider0, uint32_t ___sampleFrameCount1, const RuntimeMethod* method)
{
	NullCheck(___provider0);
	InterfaceActionInvoker1< uint32_t >::Invoke(il2cpp_codegen_method_get_slot(method), il2cpp_codegen_method_get_declaring_type(method), ___provider0, ___sampleFrameCount1);
}
void SampleFramesHandler_Invoke_m478D5645634B8C734E58B59CF7750797FC54F1BC_OpenGenericVirtual(SampleFramesHandler_tFE84FF9BBCEFB880D46227188F375BEF680AAA30* __this, AudioSampleProvider_t602353124A2F6F2AEC38E56C3C21932344F712E2* ___provider0, uint32_t ___sampleFrameCount1, const RuntimeMethod* method)
{
	NullCheck(___provider0);
	GenericVirtualActionInvoker1< uint32_t >::Invoke(method, ___provider0, ___sampleFrameCount1);
}
void SampleFramesHandler_Invoke_m478D5645634B8C734E58B59CF7750797FC54F1BC_OpenGenericInterface(SampleFramesHandler_tFE84FF9BBCEFB880D46227188F375BEF680AAA30* __this, AudioSampleProvider_t602353124A2F6F2AEC38E56C3C21932344F712E2* ___provider0, uint32_t ___sampleFrameCount1, const RuntimeMethod* method)
{
	NullCheck(___provider0);
	GenericInterfaceActionInvoker1< uint32_t >::Invoke(method, ___provider0, ___sampleFrameCount1);
}
// System.Void UnityEngine.Experimental.Audio.AudioSampleProvider/SampleFramesHandler::.ctor(System.Object,System.IntPtr)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void SampleFramesHandler__ctor_m7DDE0BAD439CD80791140C7D42D661B598A7663A (SampleFramesHandler_tFE84FF9BBCEFB880D46227188F375BEF680AAA30* __this, RuntimeObject* ___object0, intptr_t ___method1, const RuntimeMethod* method) 
{
	__this->___method_ptr_0 = il2cpp_codegen_get_virtual_call_method_pointer((RuntimeMethod*)___method1);
	__this->___method_3 = ___method1;
	__this->___m_target_2 = ___object0;
	Il2CppCodeGenWriteBarrier((void**)(&__this->___m_target_2), (void*)___object0);
	int parameterCount = il2cpp_codegen_method_parameter_count((RuntimeMethod*)___method1);
	__this->___method_code_6 = (intptr_t)__this;
	if (MethodIsStatic((RuntimeMethod*)___method1))
	{
		bool isOpen = parameterCount == 2;
		if (il2cpp_codegen_call_method_via_invoker((RuntimeMethod*)___method1))
			if (isOpen)
				__this->___invoke_impl_1 = (intptr_t)&SampleFramesHandler_Invoke_m478D5645634B8C734E58B59CF7750797FC54F1BC_OpenStaticInvoker;
			else
				__this->___invoke_impl_1 = (intptr_t)&SampleFramesHandler_Invoke_m478D5645634B8C734E58B59CF7750797FC54F1BC_ClosedStaticInvoker;
		else
			if (isOpen)
				__this->___invoke_impl_1 = (intptr_t)&SampleFramesHandler_Invoke_m478D5645634B8C734E58B59CF7750797FC54F1BC_OpenStatic;
			else
				{
					__this->___invoke_impl_1 = (intptr_t)__this->___method_ptr_0;
					__this->___method_code_6 = (intptr_t)__this->___m_target_2;
				}
	}
	else
	{
		bool isOpen = parameterCount == 1;
		if (isOpen)
		{
			if (__this->___method_is_virtual_12)
			{
				if (il2cpp_codegen_method_is_generic_instance_method((RuntimeMethod*)___method1))
					if (il2cpp_codegen_method_is_interface_method((RuntimeMethod*)___method1))
						__this->___invoke_impl_1 = (intptr_t)&SampleFramesHandler_Invoke_m478D5645634B8C734E58B59CF7750797FC54F1BC_OpenGenericInterface;
					else
						__this->___invoke_impl_1 = (intptr_t)&SampleFramesHandler_Invoke_m478D5645634B8C734E58B59CF7750797FC54F1BC_OpenGenericVirtual;
				else
					if (il2cpp_codegen_method_is_interface_method((RuntimeMethod*)___method1))
						__this->___invoke_impl_1 = (intptr_t)&SampleFramesHandler_Invoke_m478D5645634B8C734E58B59CF7750797FC54F1BC_OpenInterface;
					else
						__this->___invoke_impl_1 = (intptr_t)&SampleFramesHandler_Invoke_m478D5645634B8C734E58B59CF7750797FC54F1BC_OpenVirtual;
			}
			else
			{
				__this->___invoke_impl_1 = (intptr_t)&SampleFramesHandler_Invoke_m478D5645634B8C734E58B59CF7750797FC54F1BC_OpenInst;
			}
		}
		else
		{
			if (___object0 == NULL)
				il2cpp_codegen_raise_exception(il2cpp_codegen_get_argument_exception(NULL, "Delegate to an instance method cannot have null 'this'."), NULL);
			__this->___invoke_impl_1 = (intptr_t)__this->___method_ptr_0;
			__this->___method_code_6 = (intptr_t)__this->___m_target_2;
		}
	}
	__this->___extra_arg_5 = (intptr_t)&SampleFramesHandler_Invoke_m478D5645634B8C734E58B59CF7750797FC54F1BC_Multicast;
}
// System.Void UnityEngine.Experimental.Audio.AudioSampleProvider/SampleFramesHandler::Invoke(UnityEngine.Experimental.Audio.AudioSampleProvider,System.UInt32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void SampleFramesHandler_Invoke_m478D5645634B8C734E58B59CF7750797FC54F1BC (SampleFramesHandler_tFE84FF9BBCEFB880D46227188F375BEF680AAA30* __this, AudioSampleProvider_t602353124A2F6F2AEC38E56C3C21932344F712E2* ___provider0, uint32_t ___sampleFrameCount1, const RuntimeMethod* method) 
{
	typedef void (*FunctionPointerType) (RuntimeObject*, AudioSampleProvider_t602353124A2F6F2AEC38E56C3C21932344F712E2*, uint32_t, const RuntimeMethod*);
	((FunctionPointerType)__this->___invoke_impl_1)((Il2CppObject*)__this->___method_code_6, ___provider0, ___sampleFrameCount1, reinterpret_cast<RuntimeMethod*>(__this->___method_3));
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void AudioConfigurationChangeHandler_Invoke_m4DC27DD11512481B60071B20284E6886DAE54DE2_inline (AudioConfigurationChangeHandler_tE071B0CBA3B3A77D3E41F5FCB65B4017885B3177* __this, bool ___deviceWasChanged0, const RuntimeMethod* method) 
{
	typedef void (*FunctionPointerType) (RuntimeObject*, bool, const RuntimeMethod*);
	((FunctionPointerType)__this->___invoke_impl_1)((Il2CppObject*)__this->___method_code_6, ___deviceWasChanged0, reinterpret_cast<RuntimeMethod*>(__this->___method_3));
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Action_Invoke_m7126A54DACA72B845424072887B5F3A51FC3808E_inline (Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* __this, const RuntimeMethod* method) 
{
	typedef void (*FunctionPointerType) (RuntimeObject*, const RuntimeMethod*);
	((FunctionPointerType)__this->___invoke_impl_1)((Il2CppObject*)__this->___method_code_6, reinterpret_cast<RuntimeMethod*>(__this->___method_3));
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void PCMReaderCallback_Invoke_m76784C690C36B513E2AA5B0E4FD9831B2C7E5152_inline (PCMReaderCallback_t3396D9613664F0AFF65FB91018FD0F901CC16F1E* __this, SingleU5BU5D_t89DEFE97BCEDB5857010E79ECE0F52CF6E93B87C* ___data0, const RuntimeMethod* method) 
{
	typedef void (*FunctionPointerType) (RuntimeObject*, SingleU5BU5D_t89DEFE97BCEDB5857010E79ECE0F52CF6E93B87C*, const RuntimeMethod*);
	((FunctionPointerType)__this->___invoke_impl_1)((Il2CppObject*)__this->___method_code_6, ___data0, reinterpret_cast<RuntimeMethod*>(__this->___method_3));
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void PCMSetPositionCallback_Invoke_m434D4F02FA25F91DF6199EC5A799C551C7F93702_inline (PCMSetPositionCallback_t8D7135A2FB40647CAEC93F5254AD59E18DEB6072* __this, int32_t ___position0, const RuntimeMethod* method) 
{
	typedef void (*FunctionPointerType) (RuntimeObject*, int32_t, const RuntimeMethod*);
	((FunctionPointerType)__this->___invoke_impl_1)((Il2CppObject*)__this->___method_code_6, ___position0, reinterpret_cast<RuntimeMethod*>(__this->___method_3));
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void SampleFramesHandler_Invoke_m478D5645634B8C734E58B59CF7750797FC54F1BC_inline (SampleFramesHandler_tFE84FF9BBCEFB880D46227188F375BEF680AAA30* __this, AudioSampleProvider_t602353124A2F6F2AEC38E56C3C21932344F712E2* ___provider0, uint32_t ___sampleFrameCount1, const RuntimeMethod* method) 
{
	typedef void (*FunctionPointerType) (RuntimeObject*, AudioSampleProvider_t602353124A2F6F2AEC38E56C3C21932344F712E2*, uint32_t, const RuntimeMethod*);
	((FunctionPointerType)__this->___invoke_impl_1)((Il2CppObject*)__this->___method_code_6, ___provider0, ___sampleFrameCount1, reinterpret_cast<RuntimeMethod*>(__this->___method_3));
}
