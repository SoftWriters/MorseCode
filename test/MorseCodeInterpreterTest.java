public class MorseCodeInterpreterTest {

    public static void main(String[] args) {
        for (String path : args) {
            test(path);
        }
    }

    private static void test(String path) {
        System.out.println(path + " {\n" +
                MorseCodeInterpreter.interpret(path) +
                "\n}\n");
    }
}
