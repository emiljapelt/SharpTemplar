
namespace SharpTemplar;

public delegate Element Component();
public delegate Element Component<T0>(T0 t0);
public delegate Element Component<T0,T1>(T0 t, T1 t1);
public delegate Element Component<T0,T1,T2>(T0 t, T1 t1, T2 t2);
public delegate Element Component<T0,T1,T2,T3>(T0 t, T1 t1, T2 t2, T3 t3);
public delegate Element Component<T0,T1,T2,T3,T4>(T0 t, T1 t1, T2 t2, T3 t3, T4 t4);
public delegate Element Component<T0,T1,T2,T3,T4, T5>(T0 t, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5);

public static class Utility
{
    public static Element nothing = (state) => state;
    public static ValuedAttribute none = (state) => state;

    public static Element If(bool condition, Element e) { return If(condition, e, nothing); }
    public static Element If(bool condition, Element either, Element or) {
        if (condition) return either;
        else return or;
    }

    public static ValuedAttribute If(bool condition, ValuedAttribute e) { return If(condition, e, none); }
    public static ValuedAttribute If(bool condition, ValuedAttribute either, ValuedAttribute or) {
        if (condition) return either;
        else return or;
    }

    public static Element Attempt(Component attempt) { return Attempt(attempt, () => nothing); }
    public static Element Attempt(Component attempt, Component alternative) {
        return (state) => {
            if (state is MarkupSuccess ms) {
                var backup = ms.pointer.RefingClone();
                var id_backup = new HashSet<string>(ms.ids);
                try {
                    return attempt()(ms);
                }
                catch (Exception) {
                    ms = new MarkupSuccess(backup, id_backup);
                    return alternative()(ms);
                }
            }
            else return state;
        };
    }

    public static Element Range(int count, Element element) { return Range(0, count, (i) => element); }
    public static Element Range(int start, int count, Element element) { return Range(start, count, (i) => element); }
    public static Element Range(int count, Component<int> element) { return Range(0, count, element); }
    public static Element Range(int start, int count, Component<int> elemet){
        return (state) => {
            for(int i = start; i < start + count; i++) {
                elemet(i)(state);
            }
            return state;
        };
    }

    public static Element OnList<T>(IEnumerable<T> list, Component<T> element) {
        return (state) => {
            foreach(var e in list) {
                element(e)(state);
            }
            return state;
        };
    }
    public static Element OnList<T>(IEnumerable<T> list, Component<(int idx, T elem)> element) {
        return (state) => {
            int i = 0;
            foreach(var e in list) {
                element((i,e))(state);
                i++;
            }
            return state;
        };
    }
}