package teste.br.com.simasoft.editora.comum;

import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;
import org.junit.rules.TestWatcher;
import org.junit.runner.Description;

public class Log4JObservadorDeTeste extends TestWatcher {
	
	private final Logger logger;
	 
    public Log4JObservadorDeTeste() {
        logger = LogManager.getLogger();
    }
 
    public Log4JObservadorDeTeste(String loggerName) {
        logger = LogManager.getLogger(loggerName);
    }
    
    @Override
    protected void failed(Throwable e, Description description) {
        logger.error(description, e);
    }
 
    @Override
    protected void succeeded(Description description) {
        logger.info(description);
    }
 

}
