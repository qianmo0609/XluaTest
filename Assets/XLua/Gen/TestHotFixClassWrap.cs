#if USE_UNI_LUA
using LuaAPI = UniLua.Lua;
using RealStatePtr = UniLua.ILuaState;
using LuaCSFunction = UniLua.CSharpFunctionDelegate;
#else
using LuaAPI = XLua.LuaDLL.Lua;
using RealStatePtr = System.IntPtr;
using LuaCSFunction = XLua.LuaDLL.lua_CSFunction;
#endif

using XLua;
using System.Collections.Generic;


namespace XLua.CSObjectWrap
{
    using Utils = XLua.Utils;
    public class TestHotFixClassWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(TestHotFixClass);
			Utils.BeginObjectRegister(type, L, translator, 0, 4, 1, 1);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "get_Item", _m_get_Item);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "set_Item", _m_set_Item);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "EventCall", _m_EventCall);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "myEvent", _e_myEvent);
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "TestProperty", _g_get_TestProperty);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "TestProperty", _s_set_TestProperty);
            
			
			Utils.EndObjectRegister(type, L, translator, __CSIndexer, __NewIndexer,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 1, 0, 0);
			
			
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					TestHotFixClass gen_ret = new TestHotFixClass();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 3 && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3))
				{
					int _p = LuaAPI.xlua_tointeger(L, 2);
					int _c = LuaAPI.xlua_tointeger(L, 3);
					
					TestHotFixClass gen_ret = new TestHotFixClass(_p, _c);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to TestHotFixClass constructor!");
            
        }
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        public static int __CSIndexer(RealStatePtr L)
        {
			try {
			    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				
				if (translator.Assignable<TestHotFixClass>(L, 1) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2))
				{
					
					TestHotFixClass gen_to_be_invoked = (TestHotFixClass)translator.FastGetCSObj(L, 1);
					int index = LuaAPI.xlua_tointeger(L, 2);
					LuaAPI.lua_pushboolean(L, true);
					LuaAPI.lua_pushstring(L, gen_to_be_invoked[index]);
					return 2;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
			
            LuaAPI.lua_pushboolean(L, false);
			return 1;
        }
		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        public static int __NewIndexer(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
			try {
				
				if (translator.Assignable<TestHotFixClass>(L, 1) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2) && (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING))
				{
					
					TestHotFixClass gen_to_be_invoked = (TestHotFixClass)translator.FastGetCSObj(L, 1);
					int key = LuaAPI.xlua_tointeger(L, 2);
					gen_to_be_invoked[key] = LuaAPI.lua_tostring(L, 3);
					LuaAPI.lua_pushboolean(L, true);
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
			
			LuaAPI.lua_pushboolean(L, false);
            return 1;
        }
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_get_Item(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                TestHotFixClass gen_to_be_invoked = (TestHotFixClass)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
					string key = LuaAPI.lua_tostring(L, 2);
					LuaAPI.xlua_pushinteger(L, gen_to_be_invoked[key]);
					
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_set_Item(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                TestHotFixClass gen_to_be_invoked = (TestHotFixClass)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
					string key = LuaAPI.lua_tostring(L, 2);
					int gen_value = LuaAPI.xlua_tointeger(L, 3);
                    gen_to_be_invoked[key] = gen_value;
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_EventCall(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                TestHotFixClass gen_to_be_invoked = (TestHotFixClass)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1) 
                {
                    
                    gen_to_be_invoked.EventCall(  );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    int _a = LuaAPI.xlua_tointeger(L, 2);
                    
                    gen_to_be_invoked.EventCall( _a );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to TestHotFixClass.EventCall!");
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_TestProperty(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                TestHotFixClass gen_to_be_invoked = (TestHotFixClass)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.TestProperty);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_TestProperty(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                TestHotFixClass gen_to_be_invoked = (TestHotFixClass)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.TestProperty = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _e_myEvent(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    int gen_param_count = LuaAPI.lua_gettop(L);
			TestHotFixClass gen_to_be_invoked = (TestHotFixClass)translator.FastGetCSObj(L, 1);
                System.Action gen_delegate = translator.GetDelegate<System.Action>(L, 3);
                if (gen_delegate == null) {
                    return LuaAPI.luaL_error(L, "#3 need System.Action!");
                }
				
				if (gen_param_count == 3)
				{
					
					if (LuaAPI.xlua_is_eq_str(L, 2, "+")) {
						gen_to_be_invoked.myEvent += gen_delegate;
						return 0;
					} 
					
					
					if (LuaAPI.xlua_is_eq_str(L, 2, "-")) {
						gen_to_be_invoked.myEvent -= gen_delegate;
						return 0;
					} 
					
				}
			} catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
			LuaAPI.luaL_error(L, "invalid arguments to TestHotFixClass.myEvent!");
            return 0;
        }
        
		
		
    }
}
