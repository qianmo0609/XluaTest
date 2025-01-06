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
    public class TestPlayerWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(Test.Player);
			Utils.BeginObjectRegister(type, L, translator, 8, 8, 4, 4);
			Utils.RegisterFunc(L, Utils.OBJ_META_IDX, "__add", __AddMeta);
            Utils.RegisterFunc(L, Utils.OBJ_META_IDX, "__sub", __SubMeta);
            Utils.RegisterFunc(L, Utils.OBJ_META_IDX, "__mul", __MulMeta);
            Utils.RegisterFunc(L, Utils.OBJ_META_IDX, "__div", __DivMeta);
            Utils.RegisterFunc(L, Utils.OBJ_META_IDX, "__eq", __EqMeta);
            Utils.RegisterFunc(L, Utils.OBJ_META_IDX, "__lt", __LTMeta);
            Utils.RegisterFunc(L, Utils.OBJ_META_IDX, "__le", __LEMeta);
            Utils.RegisterFunc(L, Utils.OBJ_META_IDX, "__mod", __ModMeta);
            
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "callAtk", _m_callAtk);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "callWalk", _m_callWalk);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Equals", _m_Equals);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetHashCode", _m_GetHashCode);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ToString", _m_ToString);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "TestParam", _m_TestParam);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "TestDefualtValue", _m_TestDefualtValue);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "TestExtend", _m_TestExtend);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "Atk", _g_get_Atk);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Def", _g_get_Def);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "test2", _g_get_test2);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "testPass", _g_get_testPass);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "Atk", _s_set_Atk);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "Def", _s_set_Def);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "test2", _s_set_test2);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "testPass", _s_set_testPass);
            
			
			Utils.EndObjectRegister(type, L, translator, null, null,
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
					
					Test.Player gen_ret = new Test.Player();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to Test.Player constructor!");
            
        }
        
		
        
		
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __AddMeta(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
			
				if (translator.Assignable<Test.Player>(L, 1) && translator.Assignable<Test.Player>(L, 2))
				{
					Test.Player leftside = (Test.Player)translator.GetObject(L, 1, typeof(Test.Player));
					Test.Player rightside = (Test.Player)translator.GetObject(L, 2, typeof(Test.Player));
					
					translator.Push(L, leftside + rightside);
					
					return 1;
				}
            
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to right hand of + operator, need Test.Player!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __SubMeta(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
			
				if (translator.Assignable<Test.Player>(L, 1) && translator.Assignable<Test.Player>(L, 2))
				{
					Test.Player leftside = (Test.Player)translator.GetObject(L, 1, typeof(Test.Player));
					Test.Player rightside = (Test.Player)translator.GetObject(L, 2, typeof(Test.Player));
					
					translator.Push(L, leftside - rightside);
					
					return 1;
				}
            
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to right hand of - operator, need Test.Player!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __MulMeta(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
			
				if (translator.Assignable<Test.Player>(L, 1) && translator.Assignable<Test.Player>(L, 2))
				{
					Test.Player leftside = (Test.Player)translator.GetObject(L, 1, typeof(Test.Player));
					Test.Player rightside = (Test.Player)translator.GetObject(L, 2, typeof(Test.Player));
					
					translator.Push(L, leftside * rightside);
					
					return 1;
				}
            
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to right hand of * operator, need Test.Player!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __DivMeta(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
			
				if (translator.Assignable<Test.Player>(L, 1) && translator.Assignable<Test.Player>(L, 2))
				{
					Test.Player leftside = (Test.Player)translator.GetObject(L, 1, typeof(Test.Player));
					Test.Player rightside = (Test.Player)translator.GetObject(L, 2, typeof(Test.Player));
					
					translator.Push(L, leftside / rightside);
					
					return 1;
				}
            
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to right hand of / operator, need Test.Player!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __EqMeta(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
			
				if (translator.Assignable<Test.Player>(L, 1) && translator.Assignable<Test.Player>(L, 2))
				{
					Test.Player leftside = (Test.Player)translator.GetObject(L, 1, typeof(Test.Player));
					Test.Player rightside = (Test.Player)translator.GetObject(L, 2, typeof(Test.Player));
					
					translator.Push(L, leftside == rightside);
					
					return 1;
				}
            
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to right hand of == operator, need Test.Player!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __LTMeta(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
			
				if (translator.Assignable<Test.Player>(L, 1) && translator.Assignable<Test.Player>(L, 2))
				{
					Test.Player leftside = (Test.Player)translator.GetObject(L, 1, typeof(Test.Player));
					Test.Player rightside = (Test.Player)translator.GetObject(L, 2, typeof(Test.Player));
					
					translator.Push(L, leftside < rightside);
					
					return 1;
				}
            
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to right hand of < operator, need Test.Player!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __LEMeta(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
			
				if (translator.Assignable<Test.Player>(L, 1) && translator.Assignable<Test.Player>(L, 2))
				{
					Test.Player leftside = (Test.Player)translator.GetObject(L, 1, typeof(Test.Player));
					Test.Player rightside = (Test.Player)translator.GetObject(L, 2, typeof(Test.Player));
					
					translator.Push(L, leftside <= rightside);
					
					return 1;
				}
            
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to right hand of <= operator, need Test.Player!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __ModMeta(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
			
				if (translator.Assignable<Test.Player>(L, 1) && translator.Assignable<Test.Player>(L, 2))
				{
					Test.Player leftside = (Test.Player)translator.GetObject(L, 1, typeof(Test.Player));
					Test.Player rightside = (Test.Player)translator.GetObject(L, 2, typeof(Test.Player));
					
					translator.Push(L, leftside % rightside);
					
					return 1;
				}
            
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to right hand of % operator, need Test.Player!");
            
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_callAtk(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Test.Player gen_to_be_invoked = (Test.Player)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.callAtk(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_callWalk(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Test.Player gen_to_be_invoked = (Test.Player)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.callWalk(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Equals(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Test.Player gen_to_be_invoked = (Test.Player)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object _obj = translator.GetObject(L, 2, typeof(object));
                    
                        bool gen_ret = gen_to_be_invoked.Equals( _obj );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetHashCode(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Test.Player gen_to_be_invoked = (Test.Player)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        int gen_ret = gen_to_be_invoked.GetHashCode(  );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ToString(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Test.Player gen_to_be_invoked = (Test.Player)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        string gen_ret = gen_to_be_invoked.ToString(  );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_TestParam(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Test.Player gen_to_be_invoked = (Test.Player)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int _a = LuaAPI.xlua_tointeger(L, 2);
                    int[] _p = translator.GetParams<int>(L, 3);
                    
                    gen_to_be_invoked.TestParam( _a, _p );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_TestDefualtValue(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Test.Player gen_to_be_invoked = (Test.Player)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int _a = LuaAPI.xlua_tointeger(L, 2);
                    string _b = LuaAPI.lua_tostring(L, 3);
                    bool _c = LuaAPI.lua_toboolean(L, 4);
                    Test.Player _p = (Test.Player)translator.GetObject(L, 5, typeof(Test.Player));
                    
                    gen_to_be_invoked.TestDefualtValue( _a, _b, _c, _p );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_TestExtend(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Test.Player gen_to_be_invoked = (Test.Player)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.TestExtend(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Atk(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Test.Player gen_to_be_invoked = (Test.Player)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.Atk);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Def(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Test.Player gen_to_be_invoked = (Test.Player)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.Def);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_test2(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Test.Player gen_to_be_invoked = (Test.Player)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.test2);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_testPass(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Test.Player gen_to_be_invoked = (Test.Player)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.testPass);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Atk(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Test.Player gen_to_be_invoked = (Test.Player)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.Atk = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Def(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Test.Player gen_to_be_invoked = (Test.Player)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.Def = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_test2(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Test.Player gen_to_be_invoked = (Test.Player)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.test2 = translator.GetDelegate<Test.Player.testDelegate2>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_testPass(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Test.Player gen_to_be_invoked = (Test.Player)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.testPass = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
